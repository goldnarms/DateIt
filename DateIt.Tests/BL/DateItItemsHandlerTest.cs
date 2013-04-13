using System;
using System.Collections.Generic;
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
        private IOpenedItemHandler _openedDateItItemHandler;
        private DateItItem _appelsinJuice;
        private IAddedItemHandler _addedItemHandler;

        [TestInitialize]
        public void TestStartup()
        {
            _dateItItemHandler = new FakeDateItItemsHandler();
            _addedItemHandler = new FakeAddedItemHandler();
            _openedDateItItemHandler = new FakeOpenedDateItItemHandler(_addedItemHandler);
            _appelsinJuice = new DateItItem { Name = "AppelsinJuice", BarcodeId = 1337, ShelfLifeInDays = 4 };
            _dateItItemHandler.AddNewDateItItem(_appelsinJuice.Name, _appelsinJuice.BarcodeId, _appelsinJuice.ShelfLifeInDays);
        }

        [TestCleanup]
        public void TestTeardown()
        {
            _dateItItemHandler.RemoveAll();
            _openedDateItItemHandler.RemoveAll();
        }

        [TestMethod]
        public void ShouldBeAbleToAddNewDateItItems()
        {
            var numberOfDateItItems = _dateItItemHandler.GetAll().Count();
            _dateItItemHandler.AddNewDateItItem("Test", 3432423, 4);
            _dateItItemHandler.GetAll().Count().ShouldEqual(numberOfDateItItems + 1);
        }

        [TestMethod]
        public void ShouldBeAbleToGetItemsByName()
        {
            var appelsinjuice = _dateItItemHandler.GetByName("AppelsinJuice");
            appelsinjuice.ShouldNotBeNull();
            appelsinjuice.ShouldBeType(typeof(DateItItem));
        }

        [TestMethod]
        public void ShouldGetNullWhenAskingForNameThatDosnetExist()
        {
            var appelsinjuice = _dateItItemHandler.GetByName("NotExist");
            appelsinjuice.ShouldBeNull();
        }

        [TestMethod]
        public void ShouldBeAbleToRecordANewOpenedDateItItem()
        {
            //When opening a new Tine Appelsin juice
            var numberOfOpenedItems = _openedDateItItemHandler.GetAll().Count();
            var openedItem = _dateItItemHandler.GetByBarcode(_appelsinJuice.BarcodeId);
            _openedDateItItemHandler.OpenItem(openedItem, DateTime.Today);
            _openedDateItItemHandler.GetAll().Count().ShouldEqual(numberOfOpenedItems + 1);
        }

        [TestMethod]
        public void ShouldGetAListOfItemsThatIsOpened()
        {
            var openedItem = _dateItItemHandler.GetByBarcode(_appelsinJuice.BarcodeId);
            _openedDateItItemHandler.OpenItem(openedItem, DateTime.Today);
            _openedDateItItemHandler.GetAll().ShouldNotBeEmpty();
            _openedDateItItemHandler.GetAll().ShouldBeType<IEnumerable<OpenedItem>>();
        }

        [TestMethod]
        public void ShouldGetAListOfPreviouslyAddedItems()
        {
            var openedItem = _dateItItemHandler.GetByBarcode(_appelsinJuice.BarcodeId);
            _openedDateItItemHandler.OpenItem(openedItem, DateTime.Today);
            _addedItemHandler.Add(openedItem);
            _addedItemHandler.GetAll().ShouldContain(openedItem);
        }

        [TestMethod]
        public void ShouldAddUnknownItemsToPreviousListWhenAddingNewOpenedItem()
        {
            var dateItItem = _dateItItemHandler.GetByBarcode(_appelsinJuice.BarcodeId);
            _addedItemHandler.GetByBarcode(dateItItem.BarcodeId).ShouldBeNull();
            _openedDateItItemHandler.OpenItem(dateItItem, DateTime.Today);
            _addedItemHandler.GetByBarcode(dateItItem.BarcodeId).ShouldNotBeNull();
        }
    }
}
