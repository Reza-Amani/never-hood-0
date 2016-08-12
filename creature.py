from graphics import *
from random import *
from feature_live import *
from feature_moving import *
class Creature(object):
    """description of class"""
    def __init__(self, X, Y):
        self.x = X
        self.y = Y
        self.p = Point(X,Y)
        self.features = []
        self.features.append(feature_live(self))
        self.features.append(feature_moving(self))
        self.features[1].execute = self.features[1].random_move_1p
    def live(self):
        for feature in self.features:
            feature.execute()



