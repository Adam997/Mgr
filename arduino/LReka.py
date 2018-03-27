#!/usr/bin/python
# -*- coding: latin-1 -*-
import RPi.GPIO as GPIO
import socket
import thread
import threading
import time

# -----------------------------------------------------------------------------------
# Definicja funkcji zapisywania informacji do pliku
# -----------------------------------------------------------------------------------
def Zapis(mialByc,palec,czas ):
    global badanie
    now=time.strftime("%Y-%m-%d %H:%M:%S")
    f = open('/var/tmp/Pacjeci', 'a')
    if badanie:
        f.write('Badany: '+mialByc+' Otrzymany: '+ palec+' Czas: '+str(czas)+' Data:'+now+'\n')
    else:
        f.write(palec+'      '+now+'\n')
    #badanie=False
    f.close()


# -----------------------------------------------------------------------------------
# Definicja funkcji thread dla lampki(g?ówny thread, kontroluje dzia?anie reszty)
# -----------------------------------------------------------------------------------
def lampka(e):
    global dziala
    global start
    global badanie
    global badanyPalec
    print "zaczynam lampke"
    GPIO.output(13, False)
    while True:
        str = clisock.recv(100)
        print str
        if str == "0" or str == "1" or str == "2" or str == "3":
            badanie=True
            badanyPalec=str
            print "setuje!"
            #time.sleep(0.2)
            e.set()
            #start = time.time()
        elif str == "5":
            print "5-setuje!"
            #time.sleep(0.2)
            e.set()
        elif str == "3000":
            #global dziala 
            dziala = False
            break
    clisock.send( "papa" )
    clisock.close()
    GPIO.output(13, True)
    print "koncze lampke"

# -----------------------------------------------------------------------------------
# Definicja funkcji thread dla palców
# -----------------------------------------------------------------------------------
def palce(e):
    global dziala
    global start
    global badanyPalec
    global badanie
    nieBylo=True
    badanyPalec=0
    #global kilka
    reka="L"
    piny=[18,22,15,16];
    pal=["wskazujacy","Srodkowy","serdeczny","maly"];
    wejscia=[False,False,False,False];
    print "zaczynam palece"
    while dziala:
        print "Palec czeka na event"
        event_is_set = e.wait()
        print "Doczeka? si?!"
        start = time.time()
        nieBylo=True
        while dziala and nieBylo:
            wejscia=[GPIO.input(piny[0]),GPIO.input(piny[1]),GPIO.input(piny[2]),GPIO.input(piny[3])]
            if wejscia.count(True)>0:
                print "styk"
                for x in range(0, 6):
                    print x
                    time.sleep(0.01)
                    if wejscia!=[GPIO.input(piny[0]),GPIO.input(piny[1]),GPIO.input(piny[2]),GPIO.input(piny[3])]:
                        #time.sleep(1)
                        break
                    if x==5 and wejscia.count(True)>1:
                        str2="z"
                        print "Kilka palców"
                        czas=time.time()-start
                        Zapis(pal[int(badanyPalec)],"Kilka palców",czas)
                        clisock.send( str2+str(czas*1000)[:4] )
                        nieBylo=False
                        break
                        #if badanie:
                        #    badanie=False
                        #    time.sleep(5)
                        #else:
                        #    time.sleep(1.5)
                    if x==5 and wejscia.count(True)==1:
                        str2=pal[wejscia.index(True)]
                        print str2
                        czas=time.time()-start
                        print str(czas*1000)[:4]
                        Zapis(pal[int(badanyPalec)],str2,czas)
                        clisock.send( str2[0]+str(czas*1000)[:4] )
                        nieBylo=False
                        break
                        #if badanie:
                        #    print "d?ugi sleep"
                        #    badanie=False
                        #    time.sleep(3)
                        #else:
                        #    time.sleep(1.5)
        e.clear()
    print "koncze palece"
# -----------------------------------------------------------------------------------
# serwer soket
# -----------------------------------------------------------------------------------

# -----------------------------------------------------------------------------------

# deklaracja pinÃ³w
# -----------------------------------------------------------------------------------
GPIO.setmode(GPIO.BOARD)
GPIO.setup(13, GPIO.OUT)
GPIO.setup(15, GPIO.IN)
GPIO.setup(16, GPIO.IN)
GPIO.setup(18, GPIO.IN)
GPIO.setup(22, GPIO.IN)
# -----------------------------------------------------------------------------------
# Program
# -----------------------------------------------------------------------------------
GPIO.output(13, False)
#time.sleep(1)
#GPIO.output(13, True)
#time.sleep(1)
#GPIO.output(13, False)
#time.sleep(1)
#GPIO.output(13, True)
#global dziala 

while True:
    print "zaczynam glówny"
    while True:
        try:
            srvsock = socket.socket( socket.AF_INET, socket.SOCK_STREAM )
            srvsock.bind( ('', 2055) )
            srvsock.settimeout(2)
            srvsock.listen( 1 )
            broadcastSocket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
            broadcastSocket.setsockopt(socket.SOL_SOCKET, socket.SO_BROADCAST, 1)
            broadcastSocket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
            print "Przeszed?"
            break
        except KeyboardInterrupt:
            raise
        except:
            pass
    while True:
        #broadcastSocket.sendto(socket.gethostbyname(socket.getfqdn()) , ('<broadcast>', 8888))
        broadcastSocket.sendto("LReka" , ('<broadcast>', 8888))
        try:
            #sock, address = sckt.accept()
            GPIO.output(13, not GPIO.input(13))
            print "lacze"
            clisock, (remhost, remport) = srvsock.accept()
            break
        except socket.timeout:
            pass
    broadcastSocket.close()
    #clisock.settimout(None)

    #print "zaczynam g?ówny"
    #clisock, (remhost, remport) = srvsock.accept()
    print "po??czono"
    dziala=True
    kilka=False
    badanie=False
    start=time.time()
    e = threading.Event()
    try:
        thread.start_new_thread( lampka, (e,) )
        thread.start_new_thread( palce, (e,) )
		#thread.start_new_thread( palec, (22,"wskazujacy" ) )
		#thread.start_new_thread( palec, (18,"Srodkowy" ) )
		#thread.start_new_thread( palec, (15,"serdeczny" ) )
		#thread.start_new_thread( palec, (16,"maly" ) )
    except:
       print "Error: unable to start thread"
    while dziala:
        #if kilka==True:
        #    print "Zle palce!"
        #    clisock.send( "z" )
        #    kilka=False;
        #    time.sleep(1)
        #else:
        print "nic"
        clisock.send( "n" )
        time.sleep(2)
    #if GPIO.input(15):
    #    GPIO.output(13, False)
    #else:
    #    GPIO.output(13, True)
