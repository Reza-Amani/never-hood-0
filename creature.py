from graphics import *
from random import *
from feature_moving import *
from feature_brain import *
class Creature(object):
    """description of class"""
    def __init__(self, X, Y, world_grid, layer):
        self.x = X
        self.y = Y
        self.dx = X
        self.dy = Y
        self.layer = layer
        self.grid = world_grid
        self.point = Point(X,Y)
        self.features = []
        self.features.append(feature_brain(self))
        self.features.append(feature_moving(self))
        self.features[0].execute = self.features[0].random_move_1p_inwater
    def live(self):
        for feature in self.features:
            feature.execute()



