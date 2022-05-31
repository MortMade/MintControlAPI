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

            //Test GetByUserName
            List<FunctionModel> functionByUserName = _manager.GetByUserName("made0474@edu.zealand.dk");
            Assert.AreEqual(2,functionByUserName.Count);
        }
    }
}
