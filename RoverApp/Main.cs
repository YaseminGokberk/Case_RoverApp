using RoverApp.Classes;
using RoverApp.Resources;
using RoverApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RoverApp
{
    public partial class Main : Form
    {
        #region Fields

        private int plateauWidth;
        private int plateauHeight;
        private int horizontalGridQuantity;
        private int verticalGridQuantity;

        #endregion

        #region Constructor

        public Main()
        {
            try
            {
                // Init component.
                InitializeComponent();
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }
        }        

        #endregion

        #region Events

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                // Command line empty validation.
                if (string.IsNullOrWhiteSpace(txtCommandLine.Text))
                {
                    ShowErrorMessage("Please enter command line.");
                    return;
                }

                // Split the commands from command line.
                string[] commands = txtCommandLine.Text.Replace("\r", "").Split('\n');

                // Look inside the commands.
                for (int i = 0; i < commands.Length; i++)
                {
                    // Detect first line of input.
                    if (i == 0)
                    {
                        string[] plateauSizeCommand = commands[0].Split(' ');

                        // Incorrect first line (plateau size) validation.
                        if (plateauSizeCommand.Length != 2)
                        {
                            ShowErrorMessage(string.Format("Incorrect syntax of first line (1): '{0}'\r\nThe command must not contain spaces at the beginning or end.", commands[0]));
                            return;
                        }

                        // Incorrect first line validation.
                        int plateauX = 0;
                        int plateauY = 0;
                        if (!int.TryParse(plateauSizeCommand[0], out plateauX) || !int.TryParse(plateauSizeCommand[1], out plateauY))
                        {
                            ShowErrorMessage("The first line should contain only numbers.");
                            return;
                        }

                        // Set the main properties.
                        HorizontalGridQuantity = plateauX;
                        VerticalGridQuantity = plateauY;
                        PlateauWidth = Constants.GRID_WIDTH * HorizontalGridQuantity;
                        PlateauHeight = Constants.GRID_HEIGHT * VerticalGridQuantity;

                        // Clear plateau.
                        pnlPlateau.Controls.Clear();

                        if (HorizontalGridQuantity <= Constants.MAX_PLATEAU_WIDTH && VerticalGridQuantity <= Constants.MAX_PLATEAU_HEIGHT)
                        {
                            if (HorizontalGridQuantity > 0 && VerticalGridQuantity > 0)
                            {
                                // Divide the plateau by coordinates given from the command line.
                                DividePlateau(HorizontalGridQuantity, VerticalGridQuantity);
                            }
                            else
                            {
                                ShowErrorMessage("Plateau size must be greater than 0.");
                                break;
                            }
                        }
                        else
                        {
                            ShowErrorMessage(string.Format("Plateau size cannot be more than {0} x {1}", Constants.MAX_PLATEAU_WIDTH, Constants.MAX_PLATEAU_HEIGHT));
                            break;
                        }

                        // Continue loop.
                        continue;
                    }

                    // Empty string validation.
                    if (!string.IsNullOrWhiteSpace(commands[i]))
                    {
                        // Detect command actions.
                        // Is contains only letter then move rover.
                        if (IsAllLetters(commands[i].Replace(" ", "")))
                        {
                            // Get action command. Check action command is empty.
                            string roverActionCommand = commands[i];
                            if (!roverActionCommand.Contains(" "))
                            {
                                // Get the Rover object by name.
                                // Rover name e.g; rover0, rover1 etc.
                                Control controlItem = pnlPlateau.Controls.Find(Constants.ROVER_NAME + (i - 1), true).FirstOrDefault();
                                if (controlItem is Rover)
                                {
                                    Rover rover = (Rover)controlItem;

                                    // Check invalid rover action. Create available string collection from RoverAction enum.
                                    List<string> availableActions = new List<string>() { RoverAction.L.ToString(), RoverAction.R.ToString(), RoverAction.M.ToString() };

                                    // Look inside roverActionCommand string for invalid rover action.
                                    foreach (var action in roverActionCommand)
                                    {
                                        // If action is valid then continue.
                                        if (availableActions.Contains(action.ToString()))
                                        {
                                            // Parse string action to RoverAction enum.
                                            RoverAction roverAction = Enum.Parse<RoverAction>(action.ToString());

                                            // Check rover action.
                                            switch (roverAction)
                                            {
                                                // If rover action is L then turn 90 degree by current compass direction.
                                                // E.g; If the current direction is North, left side is west, right side is east.
                                                case RoverAction.L:
                                                    {
                                                        // Calculate turn direction.
                                                        switch (rover.Direction)
                                                        {
                                                            case Compass.N:
                                                                {
                                                                    rover.Direction = Compass.W;
                                                                    break;
                                                                }
                                                            case Compass.E:
                                                                {
                                                                    rover.Direction = Compass.N;
                                                                    break;
                                                                }
                                                            case Compass.S:
                                                                {
                                                                    rover.Direction = Compass.E;
                                                                    break;
                                                                }
                                                            case Compass.W:
                                                                {
                                                                    rover.Direction = Compass.S;
                                                                    break;
                                                                }
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    }
                                                // If rover action is R then turn 90 degree by current compass direction.
                                                case RoverAction.R:
                                                    {
                                                        switch (rover.Direction)
                                                        {
                                                            case Compass.N:
                                                                {
                                                                    rover.Direction = Compass.E;
                                                                    break;
                                                                }
                                                            case Compass.E:
                                                                {
                                                                    rover.Direction = Compass.S;
                                                                    break;
                                                                }
                                                            case Compass.S:
                                                                {
                                                                    rover.Direction = Compass.W;
                                                                    break;
                                                                }
                                                            case Compass.W:
                                                                {
                                                                    rover.Direction = Compass.N;
                                                                    break;
                                                                }
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    }
                                                // If rover action is M then move rover one unit forward by current compass.
                                                case RoverAction.M:
                                                    {
                                                        // Coordinates in units are stored on the Rover Tag property.
                                                        Point currentPoint = (Point)rover.Tag;

                                                        // Calculate move action by current compass.
                                                        switch (rover.Direction)
                                                        {
                                                            case Compass.N:
                                                                {
                                                                    rover.Tag = new Point(currentPoint.X, currentPoint.Y + 1);
                                                                    rover.Location = new Point(rover.Location.X, rover.Location.Y - Constants.GRID_HEIGHT);
                                                                    break;
                                                                }
                                                            case Compass.E:
                                                                {
                                                                    rover.Tag = new Point(currentPoint.X + 1, currentPoint.Y);
                                                                    rover.Location = new Point(rover.Location.X + Constants.GRID_WIDTH, rover.Location.Y);
                                                                    break;
                                                                }
                                                            case Compass.S:
                                                                {
                                                                    rover.Tag = new Point(currentPoint.X, currentPoint.Y - 1);
                                                                    rover.Location = new Point(rover.Location.X, rover.Location.Y + Constants.GRID_HEIGHT);
                                                                    break;
                                                                }
                                                            case Compass.W:
                                                                {
                                                                    rover.Tag = new Point(currentPoint.X - 1, currentPoint.Y);
                                                                    rover.Location = new Point(rover.Location.X - Constants.GRID_WIDTH, rover.Location.Y);
                                                                    break;
                                                                }
                                                            default:
                                                                break;
                                                        }
                                                        break;
                                                    }
                                                default:
                                                    break;
                                            }
                                        }
                                        else // Invalid rover action.
                                        {
                                            ShowErrorMessage(string.Format("Invalid rover action line at ({0}): '{1}'", i + 1, action));
                                            break;
                                        }
                                    }

                                    // Refresh Rover object for rendering.
                                    // Refresh method triggers the Rover.OnPaint(PaintEventArgs e) event.
                                    rover.Refresh();
                                }
                            }
                            else
                            {
                                // Incorrect syntax of command line.
                                ShowErrorMessage(string.Format("Incorrect syntax of command line at ({0}): '{1}'\r\nThe command must not contain spaces.", i + 1, commands[i]));
                            }
                        }
                        else if (IsAllLettersOrDigits(commands[i].Trim())) // Is contains letter or digit then spawn the rover.
                        {
                            // Get action command.
                            string spawnRoverCommand = commands[i];

                            // Check spawn rover command syntax.
                            if (spawnRoverCommand.Split(" ").Length == 3)
                            {
                                // Split spawn rover commands.
                                string[] spawnRoverCommands = spawnRoverCommand.Split(" ");

                                // Get the X coordinate.
                                int roverX = 0;
                                if (int.TryParse(spawnRoverCommands[0], out roverX))
                                {
                                    // Get the Y coordinate.
                                    int roverY = 0;
                                    if (int.TryParse(spawnRoverCommands[1], out roverY))
                                    {
                                        // Check compass direction command with Compass enum.
                                        if (Enum.IsDefined(typeof(Compass), spawnRoverCommands[2]))
                                        {
                                            // Cast string command to Compass enum.
                                            Compass roverDirection = Enum.Parse<Compass>(spawnRoverCommands[2]);

                                            // Create and spawn the Rover.
                                            Rover rover = SpawnTheRover(roverX, roverY, roverDirection);

                                            // Set the name with index number. It will then be called by that name.
                                            // E.g; rover0, rover1 etc.
                                            rover.Name = Constants.ROVER_NAME + i;
                                        }
                                        else
                                        {
                                            // Incorrect syntax order of command line.
                                            ShowErrorMessage(string.Format("Incorrect syntax order of command line at ({0}): '{1}'", i + 1, commands[i]));
                                        }
                                    }
                                    else
                                    {
                                        // Incorrect syntax order of command line.
                                        ShowErrorMessage(string.Format("Incorrect syntax order of command line at ({0}): '{1}'", i + 1, commands[i]));
                                    }
                                }
                                else
                                {
                                    // Incorrect syntax order of command line.
                                    ShowErrorMessage(string.Format("Incorrect syntax order of command line at ({0}): '{1}'", i + 1, commands[i]));
                                }
                            }
                            else
                            {
                                // Incorrect syntax of command line.
                                ShowErrorMessage(string.Format("Incorrect syntax of command line at ({0}): '{1}'\r\nThe command must not contain spaces at the beginning or end.", i + 1, commands[i]));
                            }
                        }
                        else
                        {
                            // Incorrect syntax of command line.
                            ShowErrorMessage(string.Format("Incorrect syntax of command line at ({0}): '{1}'", i + 1, commands[i]));
                        }
                    }
                }

                // Write to output.
                // Create string builder for text output.
                StringBuilder sBuilder = new StringBuilder();

                // Get Rover(s) object.
                for (int i = 0; i < pnlPlateau.Controls.Count; i++)
                {
                    // Find Rover by name algorithm. E.g; rover0, rover1 etc.
                    Control controlItem = pnlPlateau.Controls.Find(Constants.ROVER_NAME + i, true).FirstOrDefault();
                    if (controlItem is Rover)
                    {
                        // Cast Control to Rover object.
                        Rover currentRover = (Rover)controlItem;

                        // Refresh Rover object for rendering.
                        // Refresh method triggers the Rover.OnPaint(PaintEventArgs e) event.
                        currentRover.Refresh();

                        // Get Rover coordinates in units from Tag property.
                        Point roverPoint = (Point)currentRover.Tag;

                        // Append to builder.
                        sBuilder.Append(roverPoint.X + " " + roverPoint.Y + " " + currentRover.Direction.ToString());
                        sBuilder.Append("\r\n");
                    }
                }

                // Write result text to text box.
                txtOutput.Text = sBuilder.ToString();
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }
        }

        #endregion

        #region Methods

        void DividePlateau(int coordX, int coordY)
        {
            try
            {
                // Divide plateau by coordinates.
                for (int i = 0; i < coordX; i++)
                {
                    for (int j = 0; j < coordY; j++)
                    {
                        // Create panel object for grid interface.
                        Panel pnlBox = new Panel();
                        pnlBox.Size = new Size(Constants.GRID_WIDTH, Constants.GRID_HEIGHT);
                        pnlBox.Location = new Point((i * pnlBox.Size.Width), (j * pnlBox.Size.Height));
                        pnlBox.BackColor = Color.Wheat;
                        pnlBox.BorderStyle = BorderStyle.FixedSingle;

                        // Add to plateau panel.
                        pnlPlateau.Controls.Add(pnlBox);
                    }
                }
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }            
        }

        Rover SpawnTheRover(int x, int y, Compass direction)
        {
            // Create Rover instance with parameters.
            Rover rover = new Rover((x - 1) * Constants.GRID_WIDTH, PlateauHeight - (y * Constants.GRID_HEIGHT), Constants.GRID_WIDTH, Constants.GRID_HEIGHT, direction);

            try
            {
                // Store the coordinates in units on the Tag property.
                rover.Tag = new Point(x, y);

                // Add Rover object to plateau.
                pnlPlateau.Controls.Add(rover);

                // Bring to front and draw Rover object.
                rover.BringToFront();
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }

            // Return created Rover object.
            return rover;
        }

        bool IsAllLetters(string text)
        {
            foreach (char c in text)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        bool IsAllLettersOrDigits(string text)
        {
            if (text.Replace(" ", "").All(c => Char.IsLetterOrDigit(c)))
                return true;
            else
                return false;
        }

        void ShowErrorMessage(string text)
        {
            try
            {
                // Show the error mesage.
                MessageBox.Show(text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Focus again the command line.
                txtCommandLine.Focus();
            }
            catch (Exception Ex)
            {
                ShowErrorMessage(Ex.Message);
            }
        }

        #endregion

        #region Properties

        public int HorizontalGridQuantity 
        { 
            get 
            { 
                return horizontalGridQuantity; 
            }            
            set 
            {
                horizontalGridQuantity = value;
            }
        }

        public int VerticalGridQuantity
        {
            get
            {
                return verticalGridQuantity;
            }
            set
            {
                verticalGridQuantity = value;
            }
        }

        public int PlateauWidth
        {
            get
            {
                return plateauWidth;
            }
            set
            {
                plateauWidth = value;
            }
        }

        public int PlateauHeight
        {
            get
            {
                return plateauHeight;
            }
            set
            {
                plateauHeight = value;
            }
        }

        #endregion
    }
}
