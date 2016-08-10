﻿from graphics import *
class GUI(object):
    """description of class"""
    def __init__(self):
        self.field = GraphWin("My world", 1300, 700) 
        self.control = GraphWin("My world's control panel", 350, 200) 
        self.monitor = GraphWin("My world's monitor", 200, 300) 

        self.pause_image = Image(Point(50,50), "./images/pause.gif")
        self.pause_image.draw(self.control)
        self.go_image = Image(Point(100,50), "./images/go.gif")
        self.go_image.draw(self.control)
        self.clock_image = Image(Point(150,50), "./images/sand_clock.gif")
        self.clock_image.draw(self.control)
        self.exit_image = Image(Point(250,50), "./images/exit.gif")
        self.exit_image.draw(self.control)
        self.restart_image = Image(Point(50,100), "./images/flash.gif")
        self.restart_image.draw(self.control)

        self.txt = Text(Point(50,50), "start")
        self.txt.draw(self.monitor)
 #    txt = Text(Point(5,5), "test: %d %d %d" %(world.grid[0].x,world.grid[0].y,world.grid[0].water))
 #   txt.draw(monitor)

    def distance2(p1, p2):
        return (p1.getX()-p2.getX())**2 + (p1.getY()-p2.getY())**2    

    def get_command(self):
        mouse = self.control.checkMouse()
        if mouse == None:
            return "None"
        elif GUI.distance2( mouse, self.pause_image.getAnchor()) < 60^2 :
            return "pause"
        elif GUI.distance2( mouse, self.go_image.getAnchor()) < 60^2 :
            return "go"
        elif GUI.distance2( mouse, self.clock_image.getAnchor()) < 60^2 :
            return "clock"
        elif GUI.distance2( mouse, self.exit_image.getAnchor()) < 100^2 :
            return "exit"
        elif GUI.distance2( mouse, self.restart_image.getAnchor()) < 60^2 :
            return "restart"
        else:
            return "Null"

    def show_message(self, message):
        self.txt.setText(message)
     
    def terrain_display(self):
        r1 = Rectangle(Point(0,0),Point(600,699))
        r1.setFill("khaki")
        r1.setWidth(0)
        r1.draw(self.field)
        r2 = Rectangle(Point(600,0),Point(800,699))
        r2.setWidth(0)
        r2.setFill("lightblue")
        r2.draw(self.field)
        r3 = Rectangle(Point(800,0),Point(1100,699))
        r3.setWidth(0)
        r3.setFill("slateblue")
        r3.draw(self.field)
        r4 = Rectangle(Point(1100,0),Point(1300,699))
        r4.setWidth(0)
        r4.setFill("navy")
        r4.draw(self.field)
    


