using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
/// <summary>
/// Author: Mingi Kang
/// 
/// File Date: 11/22/2020
/// 
/// Purpose of the class: This form is designed to check if the html file is balanced properly.
/// If corresponding html tags are opened and closed the file has passed the test, fail otherwise.
/// </summary>
namespace Tangled_Web
{
    /// <summary>
    /// This form reads from the chosen html file using openFileDialog
    /// </summary>
    public partial class fileCheckerForm : Form
    {
        private StreamReader htmlFile; //html file chosen from the openFileDialog

        /// <summary>
        /// Main form that displays choice of selections for the user
        /// </summary>
        public fileCheckerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closing the form
        /// </summary>
        /// <param name="sender">User selecting the exit menu</param>
        /// <param name="e">The exit menu has been selected</param>
        private void fileExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Loading the html file behind the form, ready to be processed
        /// </summary>
        /// <param name="sender">User clicking file load menu</param>
        /// <param name="e">the file load menu has been selected</param>
        private void fileLoadMenu_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) //The user has selected a valid file
            {
                var fileStream = openFileDialog.OpenFile(); //Store the file

                htmlFile = new StreamReader(fileStream); //Store the file into object variable

                fileLabel.Text = "Loaded: " + Path.GetFileName(openFileDialog.FileName); //Indicate that the file has sucessfully loaded
                processCheckMenu.Enabled = true; //Allow the user to select the process menu
            }
            else //User did not select a file
            {
                MessageBox.Show("You did not select a file!");
            }
        }

        /// <summary>
        /// Not necessary, just for testing purposes
        /// </summary>
        /// <param name="sender">User Clicks to load a file</param>
        /// <param name="e">Event ends once file is selected</param>
        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
        }

        /// <summary>
        /// Process and determine whether the fiile is balanced correctly
        /// </summary>
        /// <param name="sender">User clicking the process menu</param>
        /// <param name="e">The process menu has been selected</param>
        private void processCheckMenu_Click(object sender, EventArgs e)
        {
            var fileContent = htmlFile.ReadToEnd(); //Store the content of the file into a local variable 

            CheckTags(fileContent); //Pass the string of html file content into the CheckTags method
        }

        /// <summary>
        /// Once tag has been opened look for end tag, and if the end tag
        /// does not exit the file is not balanced
        /// </summary>
        /// <param name="fileContent">String content of the html file</param>
        private void CheckTags(string fileContent)
        {
            fileListBox.Items.Clear(); //Clear the list box items each time process menu has been selected
            string tag = ""; //Create a local tag variable
            int i = 0; //Used to check the index of the characters
            bool openClose = true; //Used to check if the tag is open or closed
            bool withVal = true; //Used to check if there is a value with the open tag
            Stack<string> tags = new Stack<string>(); //Stack list to compare the open tag with the closed tag

            fileContent = fileContent.ToLower(); //Change all the characters to lower case

            char[] fileCharacters = fileContent.ToCharArray(); //Create an array of characters of the string html file content

            while (i < fileCharacters.Length) //Runs until the last character
            {
                openClose = true;
                withVal = true;
                if (fileCharacters[i] == '<') //Tag has been found
                {
                    while (fileCharacters[i] != '>') //Loop until the end of the tag
                    {
                        if (fileCharacters[i] == ' ') //If there is a space to indicate a value to the tag
                        {
                            tag += ">";
                            fileListBox.Items.Add("Found opening tag: " + tag); //Format the current tag and display it on the list box
                            tags.Push(tag); //Add the tag to the top of the tags Stack
                            while (fileCharacters[i] != '>') //Force to close to remove the value from the tag
                            {
                                    i++;
                            }
                            tag = "";
                            i = i - 1;
                            withVal = false; //Indicate that this tag had values
                        }
                        if ((fileCharacters[i + 1] == 'b' && fileCharacters[i + 2] == 'r') ||
                            (fileCharacters[i + 1] == 'h' && fileCharacters[i + 2] == 'r') || (fileCharacters[i + 1] == 'i' && fileCharacters[i + 2] == 'm')) //If tag is not a container
                        {
                            tags.Pop(); //Automatically remove the tag from the Stack
                            while (fileCharacters[i] != '>') //Run until the end of the tag
                            {
                                tag += Convert.ToString(fileCharacters[i]);
                                i++;
                                if (fileCharacters[i] == ' ') //If non-container tag has a value
                                {
                                    tag += ">";
                                    fileListBox.Items.Add("Found non-container tag: " + tag); //Format the current tag and display it on the list box
                                    while (fileCharacters[i] != '>') //Force to close to remove the value from the tag
                                    {
                                        i++;
                                    }
                                    tag = "";
                                    i = i - 1;
                                    withVal = false; //Indicate that this tag had values
                                }
                            }
                            if (fileCharacters[i] == '>') //Tag is a non-container with no values
                            {
                                tag += ">";
                            }

                            if (withVal) //Add the non-container tag with no value to the Stack and display it on list box
                            {
                                fileListBox.Items.Add("Found non-container tag: " + tag);
                                tags.Push(tag);
                            }
                            openClose = false; //If non of the above applies it is a closed tag
                            tag = "";
                            i = i - 1;

                        }

                        if (fileCharacters[i + 1] == '/') //Indication for closed tags
                        {
                            i = i + 2; //This is to only store the elements need to compare to the Stack
                            while (fileCharacters[i] != '>') //Collect the content of the tag without /
                            {
                                tag += Convert.ToString(fileCharacters[i]);
                                i++;
                            }
                            if (fileCharacters[i] == '>') //Add the closed tag manually
                            {
                                tag += ">";
                            }

                            fileListBox.Items.Add("Found closing tag: " + "</" + tag); //Display the closed tag on the list box
                            tag = "<" + tag;
                            if (tag == tags.Peek()) //Check to see if the closed tag a corresponding open tag
                            {
                                tags.Pop(); //Remove the balanced tag
                            }else if(tag != tags.Peek() && tags.Count != 1) //If there is a balance error
                            {
                                goto LoopEnd; //Break out of the nested loop
                            }
                            openClose = false; //Tag is still closed
                            tag = "";
                            i = i - 1;
                        }
                        tag += Convert.ToString(fileCharacters[i]); //This is collecting for the open tag
                        i++;
                    }
                    if (fileCharacters[i] == '>') //Finish collecting open tag
                    {
                        tag += ">";
                    }
                }
                if (openClose && tag != "" && withVal) //Check if the tag is open with no values
                {
                    fileListBox.Items.Add("Found opening tag: " + tag);
                    tags.Push(tag); //Stack the open tag to the top
                }
                tag = "";
                i++;
            }
            LoopEnd: //Break out point
            if (tags.Count == 0) //Indication that all tags were properly closed
            {
                fileLabel.Text = Path.GetFileName(openFileDialog.FileName) + " has balanced tags"; //Display a label to tell the user that html file is balanced
            }
            else //If there was an unclosed tag
            {
                fileLabel.Text = Path.GetFileName(openFileDialog.FileName) + " does not have balanced tags"; //Display a label to tell the user that html file is not balanced
            }
        }
    }
}
