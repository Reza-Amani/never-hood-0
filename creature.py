from graphics import *
from random import *
from feature_moving import *
class Creature(object):
    """description of class"""
    def __init__(self, X, Y):
        self.x = X
        self.y = Y
        self.p = Image(Point(X,Y),3,3)
        self.p.setPixel(0,0,'black')
#        self.p.setPixel(0,1,'black')
 #       self.p.setPixel(1,0,'black')
        self.p.setPixel(3,2,'black')
        self.feature = feature_moving(self)
    def live(self):
        self.feature.execute()



