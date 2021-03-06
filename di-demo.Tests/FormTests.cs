﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using di_demo.Tests.Server;
using Moq;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Specialized;
using di_demo.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using di_demo.Services;
using AngleSharp.Parser.Html;

namespace di_demo.Tests
{
    [TestClass]
    public class FormTests
    {
        [TestMethod]
        public void DefaultPage_TestPageInitialState()
        {

            var personRepo = new Mock<IPersonRepository>();
            var yearProvider = new Mock<IYearProvider>();

            var collection = new ServiceCollection();
            collection.AddScoped((sp) => { return personRepo.Object; });
            collection.AddScoped((sp) => { return yearProvider.Object; });

            var provider = new Services.ServiceProvider(collection.BuildServiceProvider());


            WebApplicationProxy.Create(typeof(_Default), provider);

            var page = WebApplicationProxy.GetPageByLocation<_Default>("/default.aspx", collection);

            page.RunToEvent(WebFormEvent.PreRender);

            var employeeData = page.FindControlRecursive<HtmlGenericControl>("employeeData");

            Assert.IsFalse(employeeData.Visible, "Expected employeeData control to be visible=false");


            var txtId = page.FindControlRecursive<TextBox>("txtId");

            Assert.IsTrue(txtId.Text == string.Empty, "Expected ID text box to have no value");


            personRepo.Verify(x => x.GetPerson(It.IsAny<int>()), Times.Never());


        }

        [TestMethod]
        public void DefaultPage_TestPersonDataPopulation()
        {

            var mockPerson = new Data.Entity.Person
            {
                Id = 5,
                FirstName = "Joe",
                LastName = "Brown",
                DateOfBirth = new DateTime(1980, 5, 1)
            };

            var yearProvider = new Mock<IYearProvider>();
            var personRepo = new Mock<IPersonRepository>();
            personRepo.Setup(d => d.GetPerson(It.IsAny<int>())).Returns(mockPerson);

            var collection = new ServiceCollection();
            collection.AddScoped((sp) => { return personRepo.Object; });
            collection.AddScoped((sp) => { return yearProvider.Object; });

            var provider = new Services.ServiceProvider(collection.BuildServiceProvider());


            WebApplicationProxy.Create(typeof(_Default), provider);

            var page = WebApplicationProxy.GetPageByLocation<_Default>("/default.aspx");
            page.RunToEvent(WebFormEvent.PreRender);

            var submitButton = page.FindControlRecursive<Button>("submitButton");

            var postData = new NameValueCollection();
            postData.Add("ctl00$MainContent$txtId", mockPerson.Id.ToString());
            page.MockPostData(postData);
            submitButton.FireEvent("Click", null);


            personRepo.Verify(x => x.GetPerson(It.Is<int>((val) => val == 5)), Times.Once());


            var employeeData = page.FindControlRecursive<HtmlGenericControl>("employeeData");
            Assert.IsTrue(employeeData.Visible, "Expected employeeData control to be visible");

            var LabelId = page.FindControlRecursive<Label>("LabelId");
            Assert.AreEqual<string>(LabelId.Text,mockPerson.Id.ToString());

            var LabelFirstName = page.FindControlRecursive<Label>("LabelFirstName");
            Assert.AreEqual<string>(LabelFirstName.Text, mockPerson.FirstName);

            var LabelLastName = page.FindControlRecursive<Label>("LabelLastName");
            Assert.AreEqual<string>(LabelLastName.Text, mockPerson.LastName);

            var LabelDob = page.FindControlRecursive<Label>("LabelDob");
            Assert.AreEqual<string>(LabelDob.Text, mockPerson.DateOfBirth.ToShortDateString());



            //sut.sub
            var outHTML = page.RenderHtml();


        }

        [TestMethod]
        public void DefaultPage_VerifyFooterContent()
        {

            var personRepo = new Mock<IPersonRepository>();
            var yearProvider = new Mock<IYearProvider>();

            yearProvider.Setup(x => x.CurrentYear).Returns(2000);

            var collection = new ServiceCollection();
            collection.AddScoped((sp) => { return personRepo.Object; });
            collection.AddScoped((sp) => { return yearProvider.Object; });

            var provider = new Services.ServiceProvider(collection.BuildServiceProvider());


            WebApplicationProxy.Create(typeof(_Default), provider);

            var page = WebApplicationProxy.GetPageByLocation<_Default>("/default.aspx", collection);

            page.RunToEvent(WebFormEvent.PreRender);

            var pageHtml = page.RenderHtml();

            var parser = new HtmlParser();
            var document = parser.Parse(pageHtml);
            var footerDiv = document.QuerySelectorAll("div[class=footer]");

            Assert.IsTrue(footerDiv.Length == 1, "Expected exactly one footer div");
            Assert.IsTrue(footerDiv[0].TextContent == "© 2000", "Value of label was incorrect");

        }


    }
}
