﻿using System;
using System.ComponentModel;

namespace NitroStudio2;

public partial class SaveCloseDialog
{
    private int returnValue;

    public SaveCloseDialog()
    {
        InitializeComponent();
    }

    private void SaveCloseDialog_Load(object sender, EventArgs e)
    {
    }

    private void Window_Closing(object sender, CancelEventArgs e)
    {
    }

    private void YesButton_Click(object sender, EventArgs e)
    {
        returnValue = 0;
        Close();
    }

    private void NoButton_Click(object sender, EventArgs e)
    {
        returnValue = 1;
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        returnValue = 2;
        Close();
    }


    public int getValue()
    {
        Show();
        return returnValue;
    }
}