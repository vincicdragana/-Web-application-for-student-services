using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;
using ZadatakGET.Controllers;
using ZadatakGET.Data;
using ZadatakGET.Models;
using ZadatakGET.Repository;
using ZadatakGET.ViewModel;

namespace UnitTestovi
{
    [TestClass]
    public class UnitTestStudentController
    {
        [TestMethod]
        public void StudentIndex()
        {
            StudentController sk = new StudentController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<StudentRepository> mockStudent = new Mock<StudentRepository>(new Zadatak2Context());

            mockStudent.Setup(x => x.GetAll()).Returns(SeedClass.GetStudentsTest());

            sk.UnitOfWork = mockUnit.Object;
            sk.UnitOfWork.Studenti = mockStudent.Object;
            ViewResult rezultat = sk.Index(null) as ViewResult;
            mockStudent.Verify((x => x.GetAll()), Times.Once());
            Assert.IsTrue(rezultat != null);
            Assert.AreEqual(SeedClass.GetStudentsTest().GetType(), rezultat.Model.GetType());
            //Assert.AreSame(SeedClass.GetStudentsTest(), rezultat.Model);
        }

        [TestMethod]
        public void StudentDetails()
        {
            StudentController sk = new StudentController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<StudentRepository> mockStudent = new Mock<StudentRepository>(new Zadatak2Context());

            mockStudent.Setup(x => x.FindStudent(1)).Returns(SeedClass.GetStudentsTest()[1]);

            sk.UnitOfWork = mockUnit.Object;
            sk.UnitOfWork.Studenti = mockStudent.Object;
            ViewResult rezultat = sk.Details(1) as ViewResult;
            mockStudent.Verify((x => x.FindStudent(1)), Times.Once());
            Assert.IsTrue(rezultat != null);
            Assert.AreEqual(SeedClass.GetStudentsTest()[1].GetType(), rezultat.Model.GetType());
        }

        [TestMethod]
        public void StudentCreate()
        {
            StudentController sk = new StudentController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<StudentRepository> mockStudent = new Mock<StudentRepository>(new Zadatak2Context());

            mockStudent.Setup(x => x.Create(SeedClass.GetStudentsTest()[1]));
            mockUnit.Setup(x => x.SaveChanges());

            sk.UnitOfWork = mockUnit.Object;
            sk.UnitOfWork.Studenti = mockStudent.Object;
            ViewResult rezultat = sk.Create(SeedClass.GetStudentsTest()[1]) as ViewResult;
            mockStudent.Verify((x => x.Create(It.IsAny<Student>())), Times.Once());
            mockUnit.Verify((x => x.SaveChanges()), Times.Once());
        }

        [TestMethod]
        public void StudentEdit()
        {
            StudentController sk = new StudentController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<StudentRepository> mockStudent = new Mock<StudentRepository>(new Zadatak2Context());

            mockStudent.Setup(x => x.Edit(SeedClass.GetStudentsTest()[1]));
            mockUnit.Setup(x => x.SaveChanges());

            sk.UnitOfWork = mockUnit.Object;
            sk.UnitOfWork.Studenti = mockStudent.Object;
            ViewResult rezultat = sk.Edit(new StudentModel
            {
                BI = 1,
                Ime = "Dragana",
                Prezime = "Vincic",
                Adresa = "Antifasisticke borbe 22",
                Grad = "Beograd"
            }) as ViewResult;
            mockStudent.Verify((x => x.Edit(It.IsAny<Student>())), Times.Once());
            mockUnit.Verify((x => x.SaveChanges()), Times.Once());
        }

        [TestMethod]
        public void StudentDeleteComfirmed()
        {
            StudentController sk = new StudentController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<StudentRepository> mockStudent = new Mock<StudentRepository>(new Zadatak2Context());

            mockStudent.Setup(x => x.FindStudent(SeedClass.GetStudentsTest()[1].BI)).Returns(SeedClass.GetStudentsTest()[1]);
            mockStudent.Setup(x => x.Delete(SeedClass.GetStudentsTest()[1]));
            mockUnit.Setup(x => x.SaveChanges());

            sk.UnitOfWork = mockUnit.Object;
            sk.UnitOfWork.Studenti = mockStudent.Object;
            ViewResult rezultat = sk.DeleteConfirmed(SeedClass.GetStudentsTest()[1].BI) as ViewResult;
            mockStudent.Verify((x => x.FindStudent(SeedClass.GetStudentsTest()[1].BI)), Times.Once());
            mockStudent.Verify((x => x.Delete(It.IsAny<Student>())), Times.Once());
            mockUnit.Verify((x => x.SaveChanges()), Times.Once());

        }

        [TestMethod]
        public void StudentDelete()
        {
            StudentController sk = new StudentController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<StudentRepository> mockStudent = new Mock<StudentRepository>(new Zadatak2Context());

            mockStudent.Setup(x => x.FindStudent(SeedClass.GetStudentsTest()[1].BI)).Returns(SeedClass.GetStudentsTest()[1]);

            sk.UnitOfWork = mockUnit.Object;
            sk.UnitOfWork.Studenti = mockStudent.Object;
            ViewResult rezultat = sk.Delete(SeedClass.GetStudentsTest()[1].BI) as ViewResult;
            mockStudent.Verify((x => x.FindStudent(SeedClass.GetStudentsTest()[1].BI)), Times.Once());
            Assert.AreEqual(SeedClass.GetStudentsTest()[1].GetType(), rezultat.Model.GetType());
            Assert.IsNotNull(rezultat);

        }

        [TestMethod]
        public void StudentDeleteIspitComfirmed()
        {
            StudentController sk = new StudentController();

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

            sk.UnitOfWork = mockUnit.Object;
            sk.UnitOfWork.Ispiti = mockIspit.Object;
            ViewResult rezultat = sk.DeleteIspitConfirmed(1, 1) as ViewResult;
            mockIspit.Verify((x => x.FindIspit(1, 1)), Times.Once());
            mockIspit.Verify((x => x.Delete(It.IsAny<Ispit>())), Times.Once());
            mockUnit.Verify((x => x.SaveChanges()), Times.Once());
        }

        [TestMethod]
        public void StudentDeleteIspit()
        {
            StudentController sk = new StudentController();

            Mock<UnitOfWork> mockUnit = new Mock<UnitOfWork>(new Zadatak2Context());
            Mock<IspitRepository> mockIspit = new Mock<IspitRepository>(new Zadatak2Context());

            mockIspit.Setup(x => x.FindIspit(1, 1)).Returns(new Ispit
            {
                BI = 1,
                PredmetId = 1,
                Oena = 7
            });

            sk.UnitOfWork = mockUnit.Object;
            sk.UnitOfWork.Ispiti = mockIspit.Object;
            ViewResult rezultat = sk.DeleteIspit(1, 1) as ViewResult;
            mockIspit.Verify((x => x.FindIspit(1, 1)), Times.Once());
            Assert.AreEqual(typeof(Ispit), rezultat.Model.GetType());
            Assert.IsNotNull(rezultat);

        }
    }
}
