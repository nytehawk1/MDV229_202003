﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Threading;

namespace BowmanBlain_ConvertedData
{
    class Game
    {
        public static List<Card>[] pld = new List<Card>[4]; //list cards handed out to players
        Deck d = new Deck(); //class instance creation 
        List<Card> pl1 = new List<Card>(); //list cards handed out to one player
        List<Card> pl2 = new List<Card>(); //list cards handed out to one player
        List<Card> pl3 = new List<Card>(); //list cards handed out to one player
        List<Card> pl4 = new List<Card>(); //list cards handed out to one player

        public void getcards() //cards handed out to players
        {

            d.shuffle(); //shuffle
            for (int i = 0; i < 13; i++) //cards handed out to one player at a time
            {
                pl1.Add(d.F[i]); //result list 
            }
            for (int i = 13; i < 26; i++) //cards handed out to one player at a time
            {
                pl2.Add(d.F[i]); //result list 
            }
            for (int i = 26; i < 39; i++) // cards handed out to one player at a time
            {
                pl3.Add(d.F[i]); //result list 
            }
            for (int i = 39; i < 52; i++) // cards handed out to one player at a time
            {
                pl4.Add(d.F[i]); //result list 
            }


        }
        public void game()
        {
            User[] players = new User[4]; // Array of players

            pld[0] = pl1; //put list cards handed out to one player to list cards handed out to players
            pld[1] = pl2; //put list cards handed out to one player to list cards handed out to players
            pld[2] = pl3; //put list cards handed out to one player to list cards handed out to players
            pld[3] = pl4; //put list cards handed out to one player to list cards handed out to players
            DataBase db1 = new DataBase();    //class connect to database instance creation 
            db1.OpenConnection(); //connect to database
            Random rand = new Random();
            int a = 0;
            for (int i = 0; i < 4; i++) //pull RANDOM four players from the database of restaurant reviewers
            {
                User user = new User();  //class instance creation 
                a = rand.Next(1, 100); //random id of user in the database
                string select1 = "SELECT First, Last FROM samplerestaurantdatabase.restaurantreviewers where id=" + a; //select to database
                MySqlDataReader reader = db1.DataReader(select1);
                while (reader.Read()) //reading data from database
                {
                    user.total = 0; //score player
                    user.player = i + 1; //id player
                    user.first_name = reader[0].ToString(); //first_name player
                    user.last_name = reader[1].ToString(); //last_name player
                    for (int ii = 0; ii < pld[i].Count; ii++) //sum value of all player's cards
                    {
                        user.total += int.Parse(pld[i][ii].realwhide1());
                    }
                    players[i] = user; //save players in array
                }
                reader.Close();
            }

            db1.CloseConnection();
        }
}
