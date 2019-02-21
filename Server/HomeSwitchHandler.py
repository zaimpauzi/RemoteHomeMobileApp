import mysql.connector
import time

handlerRun = 0
while handlerRun < 1:

    mydb = mysql.connector.connect(
        host="localhost",
        user="root",
        passwd="semesra30",
        database="smarthome_db"
        )   

    mycursor = mydb.cursor()
    mycursor.execute("SELECT switch1 FROM switches")
    myresult = mycursor.fetchall()

    for x in myresult:
        switchState = x[0]

    print("Switch State :   ", switchState)
    time.sleep(2)
    
    mydb.close
