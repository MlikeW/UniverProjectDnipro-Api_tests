using System.Collections.Generic;
using API.Endpoints;
using API.Messages.BooksMes;
using API.Messages.UserMes;
using API.Sender;
using CommonUtilities.Methods;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    [Binding]
    class FlowSteps
    {
        protected static Sender Send = new Sender();
        private Dictionary<string, object> content = new Content().content;

        [Given("I create user in store")]
        public void CreateUser(Table table)
        {
            var dict = table.ToHorizontalDictionary();
            var user = new CreateUser(dict["Name"], dict["Age"].ToInt(), dict["Email"], dict["Address"]);
            var userEntity = new Users(Send).CreateUserInStore(user);
            content.Add(dict["Name"], userEntity);
        }

        [When("I delete (.*) user")]
        public void DeleteUser(string userName)
            => new Users(Send).DeleteUserInStore(((SingleUser)content[userName]).ID);

        [Given("I add '(.*)' book to store")]
        public void AddBookToStore(string bookTitle)
        {
            var bookEntity = new Books(Send).CreateBook(new CreateBook(bookTitle));
            content.Add(bookTitle, bookEntity);
        }

        [When("I delete '(.*)' book from store")]
        public void DeleteBookFromStore(string userName)
            => new Books(Send).DeleteBook(((SingleBook)content[userName]).id);

        [When("I add '(.*)' book to (.*) user cart(?: (.*) times)?")]
        public void AddBookToUserCart(string bookTitle, string userName, string quantity)
        {
            if (quantity.Equals(string.Empty)) quantity = "1";
            var bookId = ((SingleBook)content[bookTitle]).id;
            var userId = ((SingleUser)content[userName]).ID;
            new Cart(Send).AddItemToCart(userId, bookId, quantity.ToInt());
        }

        [When("I create order from (.*) user cart")]
        public void ProcessOrder(string userName)
        {
            var userId = ((SingleUser)content[userName]).ID;
            new Cart(Send).ProcessOrderFromCart(userId);
        }

        [Then("I check (.*) user order (presence|absence) in store")]
        public void CheckOrder(string userName, string presence)
        {
            var count = 0;
            var userId = ((SingleUser)content[userName]).ID;
            var userOrderCount = new Orders(Send).GetUsersOrdersInfo(userId).content;
            if (presence == "presence") count = 1;
            Assert.AreEqual(userOrderCount.Count, count, "User order count doesn't equal to 1");
        }
    }
}