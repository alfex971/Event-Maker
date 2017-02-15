﻿using System;
using App1.Model;
using App1.ViewModel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddEvent()
        {
            var eventViewModel = new EventViewModel();
            var listcountbefore = eventViewModel.CatalogSingleton.list.Count;
            eventViewModel.Name = "Name we";
            eventViewModel.Description = "asdasfafasdda";
            eventViewModel.Place = "Troyan";
            eventViewModel.Date = DateTimeOffset.Now;
            eventViewModel.Time = TimeSpan.FromTicks(DateTime.Now.Ticks);
            eventViewModel.EventHandler.CreateEvent();
            var listcountactual = eventViewModel.CatalogSingleton.list.Count;
            Assert.AreEqual(listcountbefore + 1,listcountactual);
        }
    }
}
