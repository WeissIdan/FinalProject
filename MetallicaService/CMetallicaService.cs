﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
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


        public ShowList GetAllShows()
        {
            ShowsDB DB = new ShowsDB();
            return DB.SelectAll();
        }
        public Show GetShow(int id)
        {
            ShowsDB DB = new ShowsDB();
            return DB.SelectById(id);
        }
        public int InsertShow(Show show)
        {
            ShowsDB DB = new ShowsDB();
            return DB.Insert(show);
        }
        public int UpdateShow(Show show)
        {
            ShowsDB DB = new ShowsDB();
            return DB.Update(show);
        }
        public int DeleteShow(Show show)
        {
            ShowsDB DB = new ShowsDB();
            return DB.Delete(show);
        }

        public SongList GetAllSongs()
        {
            SongsDB DB = new SongsDB();
            return DB.SelectAll();
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
            return DB.Login(user);
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
            return DB.UpdateUserName(user);
        }
        public int DeleteUser(User user)
        {
            UserDB DB = new UserDB();
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
    }
}
