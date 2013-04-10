using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateIt.PCL.Interfaces;
using Should;
using DateIt.PCL.FakeServices;
using DateIt.PCL.Models;

namespace DateIt.Tests.BL
{
    [TestClass]
    public class DateItItemsHandlerTest
    {
        private IDateItItemsHandler _dateItItemHandler;
        private IOpenedDateItItemHandler _openedDateItItemHandler;
        private DateItItem _appelsinJuice; 
        [TestInitialize]
        public void TestStartup()
        {
            _dateItItemHandler = new FakeDateItItemsHandler();
            _openedDateItItemHandler = new FakeOpenedDateItItemHandler();
            _appelsinJuice = new DateItItem { Name = "AppelsinJuice", BarcodeId = 1337, ShelfLifeInDays = 4 };
            _dateItItemHandler.AddNewDateItItem(_appelsinJuice.Name, _appelsinJuice.BarcodeId, _appelsinJuice.ShelfLifeInDays);
        }

        [TestMethod]
        public void ShouldBeAbleToAddNewDateItItems()
        {
            var numberOfDateItItems = _dateItItemHandler.GetAllDateItItems().Count();
            _dateItItemHandler.AddNewDateItItem("Test", 3432423, 4);
            _dateItItemHandler.GetAllDateItItems().Count().ShouldEqual(numberOfDateItItems + 1);
        }

        [TestMethod]
        public void ShouldBeAbleToRecordANewOpenedDateItItem()
        {
            //When opening a new Tine Appelsin juice
            var numberOfOpenedItems = _openedDateItItemHandler.GetAllOpenedDateItItems().Count();
            var openedItem = _dateItItemHandler.GetDateItItemByBarcode(_appelsinJuice.BarcodeId);
            _openedDateItItemHandler.OpenItem(openedItem, DateTime.Today);
            _openedDateItItemHandler.GetAllOpenedDateItItems().Count().ShouldEqual(numberOfOpenedItems + 1);
        }
    }
}
