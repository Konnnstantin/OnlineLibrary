using Microsoft.EntityFrameworkCore;
using OnlineLibrary;
{

    UserRepository user = new UserRepository();
    user.OnCreateUser();
  //  user.SelectUsersId();

    BookRepository bookRepository = new BookRepository();
    var books = bookRepository.OnCreateModel();
}
