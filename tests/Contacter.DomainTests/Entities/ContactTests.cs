//using Contacter.Domain.Entities;
//using Contacter.Domain.Events;
//using Contacter.Domain.ValueObjects;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Contacter.Domain.Entities.Tests
//{
//    [TestClass()]
//    public class ContactTests
//    {
//        [TestMethod()]
//        public void Creating_a_new_Contact_raises_ContactCreatedEvent()
//        {
//            var contact = new Contact(
//                    name: new Name("Hans", "Peter"),
//                    email: "hanspeter@gmail.com",
//                    company: new Company("HansPeterInc", new Address("HansPeter Straat 2A", "Hilversum", "4543 AA", "Netherlands")),
//                    createdBy: Guid.NewGuid()
//                );

//            // assert events collections for this entity
//            var domainEvents = contact.GetDomainEvents();
//            Assert.IsNotNull(domainEvents);
//            Assert.AreEqual(1, domainEvents.Count);

//            // assert correct event was raised
//            var contactCreatedEvent = domainEvents.ElementAt(0) as ContactCreatedEvent;
//            Assert.IsNotNull(contactCreatedEvent);
//            Assert.AreEqual(contact.Id, contactCreatedEvent.ContactId);
//        }

//        [TestMethod()]
//        public void Creating_a_new_Contact_correctly_sets_properties()
//        {
//            var user = Guid.NewGuid();
//            var contact = new Contact(
//                name: new Name("Hans", "Peter"),
//                email: "hanspeter@gmail.com",
//                company: new Company("HansPeterInc", new Address("HansPeter Straat 2A", "Hilversum", "4543 AA", "Netherlands")),
//                createdBy: user
//            );

//            // validate name
//            Assert.AreEqual("Hans", contact.Name.First);
//            Assert.AreEqual("Peter", contact.Name.Last);

//            // validate email
//            Assert.AreEqual("hanspeter@gmail.com", contact.EmailAddress);

//            // validate company
//            Assert.AreEqual("HansPeterInc", contact.Company.Name);
//            Assert.AreEqual("HansPeter Straat 2A", contact.Company.Address.Street);
//            Assert.AreEqual("Hilversum", contact.Company.Address.City);
//            Assert.AreEqual("4543 AA", contact.Company.Address.PostalCode);
//            Assert.AreEqual("Netherlands", contact.Company.Address.Country);

//            // validate user
//            Assert.AreEqual(user, contact.CreatedBy);

//            // validate dates
//            Assert.IsNotNull(contact.CreatedOn);
//            Assert.IsNotNull(contact.UpdatedOn);
//            Assert.AreEqual(contact.CreatedOn, contact.UpdatedOn);

//            // validate contact has no notifications
//            Assert.AreEqual(0, contact.NotificationThreads.Count);
//        }

//        [TestMethod()]
//        public void Updating_only_raises_ContactUpdatedEvent_once()
//        {
//            var contact = new Contact(
//                name: new Name("Hans", "Peter"),
//                email: "hanspeter@gmail.com",
//                company: new Company("HansPeterInc", new Address("HansPeter Straat 2A", "Hilversum", "4543 AA", "Netherlands")),
//                createdBy: Guid.NewGuid()
//            );

//            contact.ClearDomainEvents();

//            contact.UpdateContactInformation(
//                name: new Name("Hans2", "Peter2"),
//                company: new Company("HansPeterInc2", new Address("HansPeter Straat 2A", "Hilversum", "4543 AA", "Netherlands")),
//                emailAddress: "hanspeter2@gmail.com"
//            );

//            // assert events collections for this entity
//            var domainEvents = contact.GetDomainEvents();
//            Assert.IsNotNull(domainEvents);
//            Assert.AreEqual(1, domainEvents.Count);

//            // assert correct events were raised
//            var contactUpdatedEvent = domainEvents.ElementAt(0) as ContactUpdatedEvent;
//            Assert.IsNotNull(contactUpdatedEvent);
//            Assert.AreEqual(contact.Id, contactUpdatedEvent.ContactId);
//        }

//        [TestMethod()]
//        public void Updating_correctly_updates_properties()
//        {
//            var contact = new Contact(
//                name: new Name("Hans", "Peter"),
//                email: "hanspeter@gmail.com",
//                company: new Company("HansPeterInc", new Address("HansPeter Straat 2A", "Hilversum", "4543 AA", "Netherlands")),
//                createdBy: Guid.NewGuid()
//            );

//            contact.ClearDomainEvents();

//            var updatedOn = contact.UpdatedOn;
//            contact.UpdateContactInformation(
//               name: new Name("Hans2", "Peter2"),
//               company: new Company("HansPeterInc2", new Address("HansPeter Straat 22A", "Hilversum2", "4543 AA2", "Netherlands2")),
//               emailAddress: "hanspeter2@gmail.com"
//            );


//            // validate name
//            Assert.AreEqual("Hans2", contact.Name.First);
//            Assert.AreEqual("Peter2", contact.Name.Last);

//            // validate email
//            Assert.AreEqual("hanspeter2@gmail.com", contact.EmailAddress);

//            // validate company
//            Assert.AreEqual("HansPeterInc2", contact.Company.Name);
//            Assert.AreEqual("HansPeter Straat 22A", contact.Company.Address.Street);
//            Assert.AreEqual("Hilversum2", contact.Company.Address.City);
//            Assert.AreEqual("4543 AA2", contact.Company.Address.PostalCode);
//            Assert.AreEqual("Netherlands2", contact.Company.Address.Country);

//            Assert.IsTrue(updatedOn < contact.UpdatedOn);
//        }

//        [TestMethod()]
//        public void Updating_only_raises_ContactUpdatedEvent_if_properties_are_different()
//        {
//            var contact = new Contact(
//                name: new Name("Hans", "Peter"),
//                email: "hanspeter@gmail.com",
//                company: new Company("HansPeterInc", new Address("HansPeter Straat 2A", "Hilversum", "4543 AA", "Netherlands")),
//                createdBy: Guid.NewGuid()
//            );

//            contact.ClearDomainEvents();

//            contact.UpdateContactInformation(
//              name: new Name("Hans", "Peter"),
//              company: new Company("HansPeterInc", new Address("HansPeter Straat 2A", "Hilversum", "4543 AA", "Netherlands")),
//              emailAddress: "hanspeter@gmail.com"
//            );

//            // no domain new events should have been raised
//            var domainEvents = contact.GetDomainEvents();
//            Assert.IsNotNull(domainEvents);
//            Assert.IsFalse(domainEvents.Any());
//        }

//        [TestMethod()]
//        public void Starting_a_new_Email_Thread_creates_a_new_Notification_Thread()
//        {
//            var contact = new Contact(
//                    name: new Name("Hans", "Peter"),
//                    email: "hanspeter@gmail.com",
//                    company: new Company("HansPeterInc", new Address("HansPeter Straat 2A", "Hilversum", "4543 AA", "Netherlands")),
//                    createdBy: Guid.NewGuid()
//                );

//            Assert.IsFalse(contact.NotificationThreads.Any());

//            contact.StartNewEmailThread();

//            Assert.AreEqual(1, contact.NotificationThreads.Count);
//            Assert.AreEqual(contact.Id, contact.NotificationThreads.ElementAt(0).Id);
//        }
//    }
//}