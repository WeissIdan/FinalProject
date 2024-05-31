using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ViewModel;




namespace MetallicaService
{
    public class CMetallicaService : IMetallicaService
    {
        public int InsertAlbum(Album album)
        {
            AlbumDB DB = new AlbumDB();
            return DB.Insert(album);
        }
        public int UpdateAlbum(Album album)
        {
            AlbumDB DB = new AlbumDB();
            return DB.Update(album);

        }
        public int DeleteAlbum(Album album)
        {
            AlbumDB DB = new AlbumDB();
            return DB.Delete(album);
        }
        public Album SelectAlbum(int id)
        {
            AlbumDB DB = new AlbumDB();
            return DB.SelectById(id);
        }
        public AlbumList GetAllAlbums()
        {
            AlbumDB DB = new AlbumDB();
            return DB.SelectAll();
        }

        public ChatList GetAllChats()
        {
            ChatDB DB = new ChatDB();
            return DB.SelectAll();
        }
        public Chat GetChat(int id)
        {
            ChatDB DB = new ChatDB();
            return DB.SelectById(id);
        }
        public int InsertChat(Chat chat)
        {
            ChatDB DB = new ChatDB();
            return DB.Insert(chat);
        }
        public int UpdateChat(Chat chat)
        {
            ChatDB DB = new ChatDB();
            return DB.Update(chat);
        }
        public int DeleteChat(Chat chat)
        {
            ChatDB DB = new ChatDB();
            return DB.Delete(chat);
        }

        public MessagesList GetAllMessages()
        {
            MessagesDB DB = new MessagesDB();
            return DB.SelectAll();
        }
        public Messages GetMessage(int id)
        {
            MessagesDB DB = new MessagesDB();
            return DB.SelectById(id);
        }
        public MessagesList GetMessagesOfChat(int chatId)
        {
            MessagesDB DB = new MessagesDB();
            return DB.SelectByChatId(chatId);
        }
        public int InsertMessage(Messages message)
        {
            MessagesDB DB = new MessagesDB();
            return DB.Insert(message);
        }
        public int UpdateMessages(Messages message)
        {
            MessagesDB DB = new MessagesDB();
            return DB.Update(message);   
        }
        public int DeleteMessages(Messages message)
        {
            MessagesDB DB = new MessagesDB();
            return DB.Delete(message);
        }
        public int DeleteMessagesByChat(Chat chat)
        {
            MessagesDB DB = new MessagesDB();
            return DB.DeleteByChat(chat);
        }

        public ShowList GetAllShows()
        {
            APIcommscs api = new APIcommscs();
            api.getAllShows();
            ShowList shows = api.getAllShows();
            return shows;
        }

        public SongList GetAllSongs()
        {
            SongsDB DB = new SongsDB();
            return DB.SelectAll();
        }
        public SongList GetAllSongsFromAlbum(int albumId)
        {
            SongsDB DB = new SongsDB();
            return DB.SelectAllSongsFromAlbum(albumId);
        }
        public Song GetSong(int id)
        {
            SongsDB DB = new SongsDB();
            return DB.SelectById(id);
        }
        public int InsertSong(Song song)
        {
            SongsDB DB = new SongsDB();
            return DB.Insert(song);
        }
        public int UpdateSong(Song song)
        {
            SongsDB DB = new SongsDB();
            return DB.Update(song);
        }
        public int DeleteSong(Song song)
        {
            SongsDB DB = new SongsDB();
            return DB.Delete(song);
        }

        public UserList GetAllUser()
        {
            UserDB DB = new UserDB();
            return DB.SelectAll();
        }
        public User GetUser(int id)
        {
            UserDB DB = new UserDB();
            return DB.SelectById(id);
        }
        public int InsertUser(User user)
        {
            UserDB DB = new UserDB();
            return DB.Insert(user);
        }
        public User Login(User user)
        {
            UserDB DB = new UserDB();
            User newUser = DB.Login(user);
            if(newUser != null && newUser.UserName == user.UserName && newUser.Password==user.Password)
            {
                return newUser;
            }
            return null;
        }
        public bool IsUserNameFree(string uname)
        {
            UserList UList = GetAllUser();
            UserList list = new UserList(UList.FindAll(user=>user.UserName==uname));
            return list.Count== 0;
        }
        public int UpdateUser(User user)
        {
            UserDB DB = new UserDB();
            return DB.UpdateUser(user);
        }
        public int DeleteUser(User user)
        {
            UserDB DB = new UserDB();
            MessagesDB MDB = new MessagesDB();
            ChatDB CDB = new ChatDB();
            RatingSystemDB RSDB = new RatingSystemDB();
            MDB.DeleteByUser(user);
            ChatList lst = CDB.SelectByManager(user);
            if (lst != null)
            {
                foreach (Chat chat in lst)
                {
                    MDB.DeleteByChat(chat);
                }
            }
            RSDB.DeleteAlbumRatingByUser(user.ID);
            RSDB.DeleteSongRatingByUser(user.ID);
            CDB.DeleteByUser(user);
            return DB.Delete(user);
        }

        public double GetSongRating(int id)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.GetSongRating(id);
        }
        public double GetAlbumRating(int id)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.GetAlbumRating(id);
        }
        public int GetAlbumRatingByUser(int albumId, int userId)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.GetAlbumRatingByUser(albumId, userId);
        }
        public int InsertSongRating(int userId, int songId, int rating)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.InsertSongR(userId, songId, rating);
        }
        public int UpdateSongRating(int userId, int songId, int rating)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.UpdateSongR(userId, songId, rating);
        }
        public int DeleteSongRating(int userId, int songId)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.DeleteSongR(userId, songId);
        }
        public int InsertAlbumRating(int userId, int albumId, int rating)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.InsertAlbumR(userId, albumId, rating);
        }
        public int UpdateAlbumRating(int userId, int albumId, int rating)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.UpdateAlbumR(userId , albumId, rating);
        }
        public int DeleteAlbumRating(int userId, int albumId)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.DeleteAlbumR(userId, albumId);
        }

        public CategoryList GetAllCategories()
        {
            CategoryDB DB = new CategoryDB();
            return DB.SelectAll();
        }
        public int InsertCategory(Category category)
        {
            CategoryDB DB = new CategoryDB();
            return DB.Insert(category);
        }

        public int UpdateCategory(Category category)
        {
            CategoryDB DB = new CategoryDB();
            return DB.Update(category);
        }

        public int DeleteCategory(Category category)
        {
            CategoryDB DB = new CategoryDB();
            return DB .Delete(category);     
        }

        public SongCategoryList GetAllSongCategory()
        {
            SongCategoryDB DB = new SongCategoryDB();
            return DB.SelectAll();
        }

        public int InsertSongCategory(SongCategory songCategory)
        {
            SongCategoryDB DB = new SongCategoryDB();
            return DB.Insert(songCategory);
        }

        public int UpdateSongCategory(SongCategory songCategory)
        {
            SongCategoryDB DB = new SongCategoryDB();
            return DB.Update(songCategory);
        }

        public int DeleteSongCategory(SongCategory songCategory)
        {
            SongCategoryDB DB = new SongCategoryDB();
            return DB.Delete(songCategory);
        }

        public void TempInsertAllSongs()
        {
            SongList lst = GetAllSongs();
            lst.RemoveRange(0, Math.Min(3, lst.Count));
            foreach (Song song in lst)
            {
                SongCategory songCategory = new SongCategory();
                songCategory.SongID = song.ID;
                for (int i = 0; i < 3; i++)
                {
                    InsertSongCategory(songCategory);
                }
            }
        }

        public SongList GetSongsByCategory(Category category)
        {
            SongsDB SCDB = new SongsDB();
            SongList list = SCDB.SelectAllSongsFromCategory(category);
            return list;
        }

        public CategoryList GetCategoryByType(Category categoryType)
        {
            CategoryDB DB = new CategoryDB();
            return DB.SelectCategoryByType(categoryType);
        }

        public int GetSongRatingByUser(int SongId, int userId)
        {
            RatingSystemDB DB = new RatingSystemDB();
            return DB.GetSongRatingByUser(SongId, userId);
        }

        public int GetLastSongId()
        {
            SongsDB DB = new SongsDB();
            return DB.GetLastID();
        }
    }
}
