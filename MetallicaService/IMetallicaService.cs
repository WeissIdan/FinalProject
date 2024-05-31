using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MetallicaService
{
    [ServiceContract]
    internal interface IMetallicaService
    {
        //abums
        [OperationContract] int InsertAlbum(Album album);
        [OperationContract] int UpdateAlbum(Album album);
        [OperationContract] int DeleteAlbum(Album album);
        [OperationContract] Album SelectAlbum(int id);
        [OperationContract] AlbumList GetAllAlbums();
        //chats
        [OperationContract] ChatList GetAllChats();
        [OperationContract] Chat GetChat(int id);
        [OperationContract] int InsertChat(Chat chat);
        [OperationContract] int UpdateChat(Chat chat);
        [OperationContract] int DeleteChat(Chat chat);      
        //messages
        [OperationContract] MessagesList GetAllMessages();
        [OperationContract] Messages GetMessage(int id);
        [OperationContract] MessagesList GetMessagesOfChat(int chatId);
        [OperationContract] int InsertMessage(Messages message);
        [OperationContract] int UpdateMessages(Messages message);
        [OperationContract] int DeleteMessages(Messages message);
        [OperationContract] int DeleteMessagesByChat(Chat chat);

        //Show
        [OperationContract] ShowList GetAllShows();      
        //songs
        [OperationContract] SongList GetAllSongs();
        [OperationContract] Song GetSong(int id);
        [OperationContract] SongList GetAllSongsFromAlbum(int albumId);
        [OperationContract] int InsertSong(Song song);
        [OperationContract] int UpdateSong(Song song);
        [OperationContract] int DeleteSong(Song song);
        [OperationContract] int GetLastSongId();
        //users
        [OperationContract] UserList GetAllUser();
        [OperationContract] User GetUser(int id);
        [OperationContract] int InsertUser(User user);
        [OperationContract] int UpdateUser(User user);
        [OperationContract] int DeleteUser(User user);
        [OperationContract] User Login(User user);
        [OperationContract] bool IsUserNameFree(string uname);
        //rating system
        [OperationContract] double GetSongRating(int id);
        [OperationContract] double GetAlbumRating(int id);
        [OperationContract] int GetAlbumRatingByUser(int albumId, int userId);
        [OperationContract] int GetSongRatingByUser(int SongId, int userId);
        [OperationContract] int InsertSongRating(int userId, int songId, int rating);
        [OperationContract] int UpdateSongRating(int userId, int songId, int rating);
        [OperationContract] int DeleteSongRating(int userId, int songId);
        [OperationContract] int InsertAlbumRating(int userId, int albumId, int rating);
        [OperationContract] int UpdateAlbumRating(int userId, int albumId, int rating);
        [OperationContract] int DeleteAlbumRating(int userId, int albumId);

        //Categories
        [OperationContract] CategoryList GetAllCategories();
        [OperationContract] int InsertCategory(Category category);
        [OperationContract] int UpdateCategory(Category category);
        [OperationContract] int DeleteCategory(Category category);
        [OperationContract] CategoryList GetCategoryByType(Category categoryType);

        //Song Category
        [OperationContract] SongCategoryList GetAllSongCategory();
        [OperationContract] int InsertSongCategory(SongCategory songCategory);
        [OperationContract] int UpdateSongCategory(SongCategory songCategory);
        [OperationContract] int DeleteSongCategory(SongCategory songCategory);
        [OperationContract] SongList GetSongsByCategory(Category category);
        [OperationContract] void TempInsertAllSongs();

    }
}
