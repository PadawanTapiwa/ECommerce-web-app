using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CaioComputers.Models;

namespace CaioComputers.Tests.Models
{
    [TestFixture]
    class CategoryRepoTest
    {
        [Test]
        public void GetCategories_isNotNull_returnsListOfCategories()
        {
            CategoryTest categoryRepo = new CategoryTest();
            var categories = categoryRepo.GetCategories();
            Assert.IsNotNull(categories);
        }
    }
}
