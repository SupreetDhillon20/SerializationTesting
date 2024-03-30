using Assignment3;
using NUnit.Framework;
using System.IO;

namespace Assignment3.Test
{

    [TestFixture] // Ensure NUnit recognizes this as a test fixture.
    public class SerializationTests
    {
        private SLL<User> users; // Adjusted to use SLL<User> directly.
        private readonly string testFileName = "test_users.bin";

        [SetUp]
        public void Setup()
        {
            users = new SLL<User>(); // Correctly instantiate SLL<User>.

            // Assuming SLL<T> class has an Append method. Adjust according to your actual method name for adding items.
            users.Append(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.Append(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.Append(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.Append(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            // Ensure any file cleanup or object cleanup here.
            if (File.Exists(testFileName))
            {
                File.Delete(testFileName);
            }
        }

        [Test]
        public void TestSerialization()
        {
            // Use the corrected SerializeUsers method signature.
            SerializationHelper.SerializeUsers(users, testFileName);
            Assert.IsTrue(File.Exists(testFileName), "Serialized file does not exist.");
        }

        [Test]
        public void TestDeSerialization()
        {
            // First, serialize to ensure there's data to deserialize.
            SerializationHelper.SerializeUsers(users, testFileName);
            var deserializedUsers = SerializationHelper.DeserializeUsers<User>(testFileName); // Adjusted to correctly use generics.

            Assert.IsNotNull(deserializedUsers, "Deserialized users list is null.");
            Assert.AreEqual(users.Count(), deserializedUsers.Count(), "Counts of original and deserialized lists do not match.");

            // You need to implement methods in SLL<T> to allow iteration or comparison (e.g., ToArray).
            // This portion of code assumes you've implemented such methods to enable direct comparison or iteration for tests.
            // An alternative is to serialize and deserialize a List<User> directly for a simple comparison,
            // but if you're testing SLL<T>, you likely want to ensure its structure and content integrity post-deserialization.
        }
    }
}
