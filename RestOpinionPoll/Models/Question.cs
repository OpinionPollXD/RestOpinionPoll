﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RestOpinionPoll.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; }

    public string Category { get; set; }

    public string Option1 { get; set; }

    public string Option2 { get; set; }

    public string Option3 { get; set; }

    public int Option1Count { get; set; }

    public int Option2Count { get; set; }

    public int Option3Count { get; set; }

    public int Option { get; set; }



    public void QuestionLength()
    {
        if (QuestionText.Length < 5)
        {
            throw new ArgumentOutOfRangeException("Question text is too short");
        }
        if (QuestionText.Length > 100)
        {
            throw new ArgumentOutOfRangeException("Question text is too long");
        }
    }

    public void CategoryLength()
    {
        if (Category.Length < 1)
        {
            throw new ArgumentOutOfRangeException("Category text is too short");
        }
        if (Category.Length > 50)
        {
            throw new ArgumentOutOfRangeException("Category text is too long");
        }
    }

    public void ValidateOption1Length()
    {
        if (Option1.Length < 1)
        {
            throw new ArgumentOutOfRangeException("Option1 text is too short");
        }
        if (Option1.Length > 50)
        {
            throw new ArgumentOutOfRangeException("Option1 text is too long");
        }
    }
    public void ValidateOption2Length()
    {
        if (Option2.Length < 1)
        {
            throw new ArgumentOutOfRangeException("Option2 text is too short");
        }
        if (Option2.Length > 50)
        {
            throw new ArgumentOutOfRangeException("Option2 text is too long");
        }
    }
    public void ValidateOption3Length()
    {
        if (Option3.Length < 1)
        {
            throw new ArgumentOutOfRangeException("Option3 text is too short");
        }
        if (Option3.Length > 50)
        {
            throw new ArgumentOutOfRangeException("Option3 text is too long");
        }
    }


    public void ValdateOption1CountRange()
    {
        if (Option1Count < 0)
        {
            throw new ArgumentOutOfRangeException("Option count is too low");
        }

    }

    public void ValdateOption2CountRange()
    {
        if (Option2Count < 0)
        {
            throw new ArgumentOutOfRangeException("Option count is too low");
        }

    }

    public void ValdateOption3CountRange()
    {
        if (Option3Count < 0)
        {
            throw new ArgumentOutOfRangeException("Option count is too low");
        }

    }


    public void Validate()
    {
        QuestionLength();
        CategoryLength();
        ValidateOption1Length();
        ValidateOption2Length();
        ValidateOption3Length();
        ValdateOption1CountRange();
        ValdateOption2CountRange();
        ValdateOption3CountRange();
       
       
    }   

}