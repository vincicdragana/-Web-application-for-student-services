using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZadatakGET.Controllers;
using ZadatakGET.Data;
using ZadatakGET.Models;
using ZadatakGET.Repository;
using ZadatakGET.ViewModel;

namespace UnitTestovi
{
    [TestClass]
    public class UnitTestIspitController
    {
        [TestMethod]
        public void IspitIndex()
        {
            IspitController ik = new IspitController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<IspitRepository> mockIspit = new Mock<IspitRepository>(new Zadatak2Context());

            mockIspit.Setup(x => x.GetAll()).Returns(SeedClass.GetIspitsTest());

            ik.UnitOfWork = mockUnit.Object;
            ik.UnitOfWork.Ispiti = mockIspit.Object;
            ViewResult rezultat = ik.Index(null) as ViewResult;
            mockIspit.Verify((x => x.GetAll()), Times.Once());
            Assert.IsTrue(rezultat != null);
            Assert.AreEqual(SeedClass.GetIspitsTest().GetType(), rezultat.Model.GetType());
            //Assert.AreSame(SeedClass.GetStudentsTest(), rezultat.Model);
        }

        [TestMethod]
        public void IspitDetails()
        {
            IspitController ik = new IspitController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<IspitRepository> mockIspit = new Mock<IspitRepository>(new Zadatak2Context());

            mockIspit.Setup(x => x.FindIspit(1, 1)).Returns(SeedClass.GetIspitsTest()[1]);

            ik.UnitOfWork = mockUnit.Object;
            ik.UnitOfWork.Ispiti = mockIspit.Object;
            ViewResult rezultat = ik.Details(1, 1) as ViewResult;
            mockIspit.Verify((x => x.FindIspit(1, 1)), Times.Once());
            Assert.IsTrue(rezultat != null);
            Assert.AreEqual(SeedClass.GetIspitsTest()[1].GetType(), rezultat.Model.GetType());
        }

        [TestMethod]
        public void IspitCreate()
        {
            IspitController ik = new IspitController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<IspitRepository> mockIspit = new Mock<IspitRepository>(new Zadatak2Context());

            mockIspit.Setup(x => x.GetAll()).Returns(SeedClass.GetIspitsTest());
            mockIspit.Setup(x => x.Create(new Ispit { BI = 10, PredmetId = 2, Oena = 7 }));
            mockUnit.Setup(x => x.SaveChanges());

            ik.UnitOfWork = mockUnit.Object;
            ik.UnitOfWork.Ispiti = mockIspit.Object;
            ViewResult rezultat = ik.Create(new Ispit { BI = 10, PredmetId = 2, Oena = 7 }) as ViewResult;
            mockIspit.Verify((x => x.GetAll()), Times.Once());
            mockIspit.Verify((x => x.Create(It.IsAny<Ispit>())), Times.Once());
            mockUnit.Verify((x => x.SaveChanges()), Times.Once());
        }

        [TestMethod]
        public void IspitEdit()
        {
            IspitController ik = new IspitController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<IspitRepository> mockIspit = new Mock<IspitRepository>(new Zadatak2Context());
            Mock<PredmetRepository> mockPredmet = new Mock<PredmetRepository>(new Zadatak2Context());
            Mock<StudentRepository> mockStudent = new Mock<StudentRepository>(new Zadatak2Context());

            mockIspit.Setup(x => x.Edit(new Ispit { BI = 10, PredmetId = 2, Oena = 7 }));
            mockUnit.Setup(x => x.SaveChanges());
            mockPredmet.Setup(x => x.GetAll()).Returns(SeedClass.GetPredmets());
            mockStudent.Setup(x => x.GetAll()).Returns(SeedClass.GetStudentsTest());

            ik.UnitOfWork = mockUnit.Object;
            ik.UnitOfWork.Ispiti = mockIspit.Object;
            ViewResult rezultat = ik.Edit(new IspitModel { BI = 10, PredmetId = 2, Oena = 7 }) as ViewResult;
            mockIspit.Verify((x => x.Edit(It.IsAny<Ispit>())), Times.Once());
            mockUnit.Verify((x => x.SaveChanges()), Times.Once());
            mockPredmet.Verify((x => x.GetAll()), Times.Exactly(0));
            mockStudent.Verify((x => x.GetAll()), Times.Exactly(0));
        }

        [TestMethod]
        public void IspitDeleteComfirmed()
        {
            IspitController ik = new IspitController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<IspitRepository> mockIspit = new Mock<IspitRepository>(new Zadatak2Context());

            mockIspit.Setup(x => x.FindIspit(1, 1)).Returns(new Ispit
            {
                BI = 1,
                PredmetId = 1,
                Oena = 7
            });
            mockIspit.Setup(x => x.Delete(new Ispit
            {
                BI = 1,
                PredmetId = 1,
                Oena = 7
            }));
            mockUnit.Setup(x => x.SaveChanges());

            ik.UnitOfWork = mockUnit.Object;
            ik.UnitOfWork.Ispiti = mockIspit.Object;
            ViewResult rezultat = ik.DeleteConfirmed(1, 1) as ViewResult;
            mockIspit.Verify((x => x.FindIspit(1, 1)), Times.Once());
            mockIspit.Verify((x => x.Delete(It.IsAny<Ispit>())), Times.Once());
            mockUnit.Verify((x => x.SaveChanges()), Times.Once());
        }

        [TestMethod]
        public void StudentDeleteIspit()
        {
            StudentController ik = new StudentController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<IspitRepository> mockIspit = new Mock<IspitRepository>(new Zadatak2Context());

            mockIspit.Setup(x => x.FindIspit(1, 1)).Returns(new Ispit
            {
                BI = 1,
                PredmetId = 1,
                Oena = 7
            });

            ik.UnitOfWork = mockUnit.Object;
            ik.UnitOfWork.Ispiti = mockIspit.Object;
            ViewResult rezultat = ik.DeleteIspit(1,1) as ViewResult;
            mockIspit.Verify((x => x.FindIspit(1, 1)), Times.Once());
            Assert.AreEqual(typeof(Ispit), rezultat.Model.GetType());
            Assert.IsNotNull(rezultat);

        }
    }
}
