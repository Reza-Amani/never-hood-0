from graphics import *
from random import *
from feature_moving import *
class Creature(object):
    """description of class"""
    def __init__(self, X, Y, world_grid):
        self.x = X
        self.y = Y
        self.grid = world_grid
        self.p = Point(X,Y)
        self.features = []
        self.features.append(feature_moving(self))
        self.features[0].execute = self.features[0].random_move_1p
    def live(self):
        for feature in self.features:
            feature.execute()



