from graphics import *
from random import *
from feature_moving import *
class Creature(object):
    """description of class"""
    def __init__(self, X, Y):
        self.x = X
        self.y = Y
        self.p = Point(X,Y)
        self.feature = feature_moving(self)
    def live(self):
        self.feature.execute()



