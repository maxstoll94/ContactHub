//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Contacter.Domain.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Contacter.Domain.Events;
//using Contacter.Domain.ValueObjects;

//namespace Contacter.Domain.Entities.Tests
//{
//    [TestClass()]
//    public class NotificationThreadTests
//    {
//        [TestMethod()]
//        public void Creating_a_new_NotificationThread_raises_NotificationThreadCreatedEvent()
//        {
//            var notificationThread = NotificationThread.CreateEmailThread(Guid.NewGuid()); 

//            // assert events collections for this entity
//            var domainEvents = notificationThread.GetDomainEvents();
//            Assert.IsNotNull(domainEvents);
//            Assert.AreEqual(1, domainEvents.Count);

//            // assert correct event was raised
//            var notificationThreadCreatedEvent = domainEvents.First() as NotificationThreadCreatedEvent;
//            Assert.IsNotNull(notificationThreadCreatedEvent);
//            Assert.AreEqual(notificationThread.Id, notificationThreadCreatedEvent.NotificationThreadId);
//        }

//        [TestMethod()]
//        public void Creating_a_new_Contact_correctly_sets_properties()
//        {
//            var contact = Guid.NewGuid();
//            var notificationThread = NotificationThread.CreateEmailThread(contact);

//            // validate states
//            Assert.AreEqual(NotificationThreadStatus.Open, notificationThread.Status);
//            Assert.AreEqual(NotificationThreadType.Email, notificationThread.Type);

//            // validate contact
//            Assert.AreEqual(contact, notificationThread.ContactId);

//            // validate dates
//            Assert.IsNotNull(notificationThread.CreatedOn);
//            Assert.IsNotNull(notificationThread.UpdatedOn);
//            Assert.AreEqual(notificationThread.CreatedOn, notificationThread.UpdatedOn);
//        }
//    }
//}