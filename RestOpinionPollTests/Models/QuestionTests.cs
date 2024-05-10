using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestOpinionPoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOpinionPoll.Models.Tests
{
    [TestClass()]
    public class QuestionTests
    {

        [TestMethod]
        public void QuestionLengthTest()
        {
            // Arrange
            Question questionLimitLow = new Question();
            questionLimitLow.QuestionText = "color";
            // Act
            questionLimitLow.QuestionLength();
         
            Question questionLimitHigh = new Question();
            questionLimitHigh.QuestionText = "1234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911234567891";
            questionLimitHigh.QuestionLength();

            Question questionLimitToShort = new Question();
            questionLimitToShort.QuestionText = "fjf";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => questionLimitToShort.QuestionLength()); 

            Question questionLimitToLong = new Question();
            questionLimitToLong.QuestionText = "12345678911234567891123456789112345678911234567891123456789112345678911234567891123456789112345678911";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => questionLimitToLong.QuestionLength());
        }

        [TestMethod()]
        public void CategoryLengthTest()
        {
            Question categoryLimitLow = new Question();
            categoryLimitLow.Category = "a";
            categoryLimitLow.CategoryLength();

            Question categoryLimitHigh = new Question();
            categoryLimitHigh.Category = "12345678901234567890123456789012345678901234567890";
            categoryLimitHigh.CategoryLength();

            Question categoryLimitToShort = new Question();
            categoryLimitToShort.Category = "";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => categoryLimitToShort.CategoryLength());

            Question categoryLimitToLong = new Question();
            categoryLimitToLong.Category = "123456789012345678901234567890123456789012345678901";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => categoryLimitToLong.CategoryLength());

        }

        [TestMethod()]
        public void ValidateOption1LengthTest()
        {
            Question option1LimitLow = new Question();
            option1LimitLow.Option1 = "a";
            option1LimitLow.ValidateOption1Length();

            Question option1LimitHigh = new Question();
            option1LimitHigh.Option1 = "12345678901234567890123456789012345678901234567890";
            option1LimitHigh.ValidateOption1Length();

            Question option1LimitToShort = new Question();
            option1LimitToShort.Option1 = "";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => option1LimitToShort.ValidateOption1Length());

            Question option1LimitToLong = new Question();
            option1LimitToLong.Option1 = "123456789012345678901234567890123456789012345678901";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => option1LimitToLong.ValidateOption1Length());
        }

        [TestMethod()]  
        public void ValidateOption2LengthTest()
        {
            Question option2LimitLow = new Question();
            option2LimitLow.Option2 = "a";
            option2LimitLow.ValidateOption2Length();

            Question option2LimitHigh = new Question();
            option2LimitHigh.Option2 = "12345678901234567890123456789012345678901234567890";
            option2LimitHigh.ValidateOption2Length();

            Question option2LimitToShort = new Question();
            option2LimitToShort.Option2 = "";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => option2LimitToShort.ValidateOption2Length());

            Question option2LimitToLong = new Question();
            option2LimitToLong.Option2 = "123456789012345678901234567890123456789012345678901";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => option2LimitToLong.ValidateOption2Length());
        }

        [TestMethod()]
        public void ValidateOption3LengthTest()
        {
            Question option3LimitLow = new Question();
            option3LimitLow.Option3 = "a";
            option3LimitLow.ValidateOption3Length();

            Question option3LimitHigh = new Question();
            option3LimitHigh.Option3 = "12345678901234567890123456789012345678901234567890";
            option3LimitHigh.ValidateOption3Length();

            Question option3LimitToShort = new Question();
            option3LimitToShort.Option3 = "";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => option3LimitToShort.ValidateOption3Length());

            Question option3LimitToLong = new Question();
            option3LimitToLong.Option3 = "123456789012345678901234567890123456789012345678901";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => option3LimitToLong.ValidateOption3Length());
        }

        [TestMethod()]
        public void ValidateOption1CountTest()
        {
            Question optionCountLimit = new Question();
            optionCountLimit.Option1Count = 0;
            optionCountLimit.ValdateOption1CountRange();

            Question optionCountUnderZero = new Question();
            optionCountUnderZero.Option1Count = -1;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => optionCountUnderZero.ValdateOption1CountRange());
           
        }

        [TestMethod()]
        public void ValidateOption2CountTest()
        {
            Question optionCountLimit = new Question();
            optionCountLimit.Option2Count = 0;
            optionCountLimit.ValdateOption2CountRange();

            Question optionCountUnderZero = new Question();
            optionCountUnderZero.Option2Count = -1;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => optionCountUnderZero.ValdateOption2CountRange());
        }

        [TestMethod()]
        public void ValidateOption3CountTest()
        {
            Question optionCountLimit = new Question();
            optionCountLimit.Option3Count = 0;
            optionCountLimit.ValdateOption3CountRange();

            Question optionCountUnderZero = new Question();
            optionCountUnderZero.Option3Count = -1;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => optionCountUnderZero.ValdateOption3CountRange());
        }
        

    }
}