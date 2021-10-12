﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel
{
    class Program
    {
        static void Main(string[] args)
        {
            #Hello World
import random
durchgang = 0
aktiv = True
beg = None
end = None

 

import mysql.connector
mydb = mysql.connector.connect(
host="4.159.237.160",
user="Admin1",
password="P!zza1337",
database="DennisDB"
)
mycursor = mydb.cursor()

 

def GetUserID(pusername):
    mycursor.execute("SELECT user_id FROM Users Where Benutzername = '%s' " %str(pusername))
    query = mycursor.fetchone()[0]
    pusername = query
    return pusername

 

def anmeldung():
    print("Bitte melde dich an: ")
    print("bist du schon registriert? y/n ")
    Logintest = exceptionString()
    
    if Logintest == "y":
        istlogin = 1
        while istlogin != 0:
            print("Okay, dann bitte Benutzername eingeben: ")
            username = input()
            print("Und das Passwort dazu: ")
            pword = input()
            istlogin = authentifizierung(username, pword)
            return username
    else:
        print("schade, hast keine Konto, Jetzt, kannst du es anlegen")
        username = input("Gib deinen Benutzeramen ein: ")
        pword = input("Und dazu dein Passwort: (max 15 Zeichen)")
        mail = input("Dazu noch deine Email: ")
        vorname = input("Wie ist dein Vorname? ")
        nachname= input("Wie ist dein Nachname? ")
        registration = (nachname, vorname, username, mail, pword )
        mycursor.execute("INSERT INTO Users (name, Vorname, Benutzername, email, Passwort) VALUES (%s ,%s ,%s ,%s ,%s)" ,registration)
        mydb.commit()
        return username

 

def authentifizierung(username, password):
    mycursor.execute("SELECT count(*) FROM Users WHERE Benutzername = '%s'" %username)
    countbenutzername = mycursor.fetchone()[0]
    if countbenutzername == 0:
        print("Benutzername ungültig")
        return(1)
    elif countbenutzername > 1:
        print("SCHWERLIEGENDER FEHLER DER DATENBANK")
        return(1)
    else:
        print("Benutzername gefunden")
    mycursor.execute("SELECT Passwort FROM Users where Benutzername = '%s' " %username)
    remotepassword = mycursor.fetchone()[0]
    #print(remotepassword)
    if remotepassword != password:
        print("Password ungültig")
        return(1)
    return(0)

 

def exceptionString():
    test = None
    while test == None:
        try:
            test = str(input("y/n: "))
            if test == "y" or test == "n":
                response = test
            else:
                print("Bitte nur mit y oder n antworten")
                test = None
        except:
            print("Es ist wohl etwas schief gegangen, noch einmal versuchen:")
    return response

 

def GetScoreID():
    mycursor.execute("SELECT MAX(score_ID) FROM Scores")
    query = mycursor.fetchone()[0]
    return query

 

username = anmeldung()
print()
name = input("Wer sitz hier vor mir? ")
print()
print()
beg = int (input("ab welcher zahl soll es beginnen? "))
end = int (input("bis zur welcher Zahl soll de Bereich sein? "))

 

ratezahl = random.randint(beg,end)
print()
print("Lass uns mal Anfangen %s !! " %name) 
print()
 
def devidespaces(arg1,arg2):
    m = arg1-len(str(arg2))
    if (m%2) == 0:
        n = m/2
        o = n
    else:
        n = m/2
        o = n +1
    formatierung = int(n) * " " +str(arg2)+int(o) * " "
    return formatierung
while True:
    durchgang = durchgang + 1
    print()
    print("Runde %s " %durchgang)
    benutzereingabe = int(input("Bitte Zahl eingeben: ")) 

 

    if benutzereingabe == ratezahl:
        print()
        print("Gute Arbeit %s " %name)
        print()
        print("Du hast die Zahl erraten! ")
        print()
        print("du hast %s ,Runden gebraucht" %durchgang)
        print()
        again = input("willst du noch eine Runde spielen? (yes/no): ")
        print()
        Score = (end - beg) / durchgang 
        scoreinfos = (durchgang, beg, end, Score)
        mycursor.execute("INSERT INTO Scores (Versuche, Start, Ende, Score) VALUES ( %s, %s, %s, %s)" ,scoreinfos)
        mydb.commit()
        speicherUsername = GetUserID(username)
        speicherScore = GetScoreID()
        mycursor.execute("INSERT INTO Game (user_id, score_id) VALUES (%s, %s)" %(speicherUsername,speicherScore))
        mydb.commit()
        mycursor.execute("SELECT Benutzername, Versuche, Score FROM Scores, Game , Users Where Users.user_id = Game.user_id AND Game.score_id = Scores.score_id ORDER BY Score DESC LIMIT 10" )
        scoreboard = mycursor.fetchall()
        mycursor.execute("""SELECT Game.score_id FROM Game, Scores Where Scores.score_id = Game.score_id
        ORDER BY Score DESC LIMIT 10
        """) 
        speicherGameID = mycursor.fetchall()
        print("---------------------------------Top10--------------------------------------")
        print("         Benutzername            Versuche        Punkte")
        x = 0 
        for i in scoreboard:
            cusername = devidespaces(30,i[0])
            cversuche = devidespaces(9,i[1])
            cscore = devidespaces(15,i[2])
            libname = speicherGameID[x]
            if speicherScore == libname[0]:
                print(cusername+" "+cversuche+" "+cscore+"<---- das bisch du!") 
            else:
                print(cusername+" "+cversuche+" "+cscore)
            x += 1
        print("----------------------Nur die coolen komm in den Garten---------------------")
        if again == 'yes':
            print("ok noch eine Runde")            
            durchgang = 0
            print(" %s dann müsstest du mir ein neuen spiel Bereich Mitteilen? " %name)
            beg = int (input("Wo soll es Jetzt Beginne? "))
            end = int (input("Und wo soll es jetzt Enden? "))
            ratezahl = random.randint(beg,end)
            
        else:
            print("Mann sieht sich: ")
            aktiv = False
            
            break

 


    elif benutzereingabe > ratezahl:
        print()
        print("Mensch %s " %name)
        print("deine Zahl ist vieeel zu groß! ")
    else:
        print()
        print("Mensch %s " %name)
        print("Deine Zahl ist zu klein! ")
        }
    }
}
