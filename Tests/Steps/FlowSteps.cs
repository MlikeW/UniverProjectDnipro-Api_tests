using System.Collections.Generic;
using System.Linq;
using API.Endpoints;
using API.Messages.BooksMes;
using API.Messages.OrdersMes;
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
            var userInfo = table.ToHorizontalDictionary();
            var user = new CreateUser(userInfo["Name"], userInfo["Age"].ToInt(), userInfo["Email"], userInfo["Address"]);
            var userEntity = new Users(Send).CreateUserInStore(user);
            content.Add(userInfo["Name"], userEntity);
        }

        [When("I delete (.*) user")]
        public void DeleteUser(string userName)
            => new Users(Send).DeleteUserInStore(((SingleUser)content[userName]).ID);

        [Given("I add '(.*)' book to store")]
        [When("I add '(.*)' book to store")]
        public void AddBookToStore(string bookTitle)
            => content.Add(bookTitle, new Books(Send).CreateBook(new CreateBook(bookTitle)));

        [When("I delete '(.*)' book from store")]
        public void DeleteBookFromStore(string userName)
            => new Books(Send).DeleteBook(((SingleBook)content[userName]).id);

        [When("I add '(.*)' book to (.*) user cart(?: (.*) times)?")]
        public void AddBookToUserCart(string bookTitle, string userName, string quantity)
        {
            if (quantity.Equals(string.Empty))
            {
                quantity = "1";
            }
            var bookId = ((SingleBook)content[bookTitle]).id;
            var userId = ((SingleUser)content[userName]).ID;
            new Cart(Send).AddItemToCart(userId, bookId, quantity.ToInt());
        }

        [When("I create order from (.*) user cart")]
        public void ProcessOrder(string userName)
            => new Cart(Send).ProcessOrderFromCart(((SingleUser)content[userName]).ID);

        [Then("I check (.*) user order (presence|absence) in store")]
        public void CheckOrder(string userName, string presence)
        {
            var count = 0;
            var userId = ((SingleUser)content[userName]).ID;
            var userOrderCount = new Orders(Send).GetUsersOrdersInfo(userId).content;
            if (presence == "presence")
            {
                count = 1;
            }
            Assert.AreEqual(userOrderCount.Count, count, "User order count doesn't equal to 1");
        }

        [When("I delete '(.*)' book from (.*) user cart")]
        public void DeleteBookFromCart(string bookTitle, string userName)
            => new Cart(Send).DeleteItemFromCart(
                ((SingleUser)content[userName]).ID, 
                ((SingleBook)content[bookTitle]).id);

        [Then("(.*) user order contain books")]
        public void DeleteBookFromCart(string userName, Table table)
        {
            var expectedListOfBooks = table.ToList().Select(book => 
                ((SingleBook)content[book]).id).ToList();
            var actualListOfBooks
                = new Orders(Send)
                    .GetUsersOrdersInfo(((SingleUser) content[userName]).ID)
                    .content
                    .First()
                    .orderDetails
                    .orderItems
                    .Select(item => item.itemId)
                    .ToList();
            Assert.AreEqual(expectedListOfBooks, actualListOfBooks, "Expected and actual lists of books are not equal");
        }
    }
}