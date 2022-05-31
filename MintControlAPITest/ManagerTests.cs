using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using MintControlAPI;
using MintControlAPI.Controllers;
using MintControlAPI.Managers;
using MintControlAPI.Models;
using System.Collections.Generic;

namespace MintControlAPITest
{
    [TestClass]
    public class ManagerTests
    {
        private FunctionsManager _manager;
        private readonly MintContext _context;
        private FunctionsController _controller;

        public ManagerTests()
        {
            DbContextOptionsBuilder<MintContext> options = new DbContextOptionsBuilder<MintContext>();
            options.UseSqlServer(Secrets.ConnectionString);
            _context = new MintContext(options.Options);
        }

        [TestInitialize]
        public void Init()
        {
            _manager = new FunctionsManager(_context);
            _controller = new FunctionsController(_context);
        }

        [TestMethod]
        public void ManagerFunctionsTest()
        {
            //Test GetAll metoder
            List<FunctionModel> allFunctions = _manager.GetAll();
            int sizeOfFunctions = allFunctions.Count;
            Assert.AreEqual(sizeOfFunctions, allFunctions.Count);

            //Test GetNoUserName
            List<FunctionModel> functionNoUserName = _manager.GetByUserName("");
            Assert.AreEqual(1, functionNoUserName.Count);

            //Test GetByUserName
            List<FunctionModel> functionByUserName = _manager.GetByUserName("made0474@edu.zealand.dk");
            Assert.AreNotEqual(1, functionByUserName.Count);
        }

        [TestMethod]
        public void ManagerPostDeleteFunctionsTest()
        {
            // Test Add
            List<FunctionModel> allFunctions = _manager.GetAll();
            FunctionModel newFunc = new FunctionModel();
            newFunc.Title = "Test";
            newFunc.Command = "Test";
            newFunc.UserId = 4;
            newFunc.FuncRights = 0;
            int sizeAllFunctions = allFunctions.Count;
            _manager.Add(newFunc);
            allFunctions = _manager.GetAll();
            Assert.AreEqual(allFunctions.Count, sizeAllFunctions + 1);

            // Test Delete
            _manager.Delete(newFunc.FuncId);
            allFunctions = _manager.GetAll();
            Assert.AreEqual(allFunctions.Count, sizeAllFunctions);

        }
        [TestMethod]
        public void ManagerUpdateFunctionsTest()
        {
            // Test Update
            List<FunctionModel> allFunctions = _manager.GetAll();
            FunctionModel getIdFunc = _manager.GetById(1);
            Assert.AreEqual("SendFireworks", getIdFunc.Title);
            getIdFunc.Title = "SendLove";
            _manager.Update(getIdFunc.FuncId, getIdFunc);
            FunctionModel getIdFunc2 = _manager.GetById(1);
            Assert.AreEqual(getIdFunc.Title, getIdFunc2.Title);
            getIdFunc.Title = "SendFireworks";
            _manager.Update(getIdFunc.FuncId, getIdFunc);
        }
    }
}
