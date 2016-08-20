from globals import *
from graphics import *
from random import *
from feature_moving import *
from feature_brain import *
from feature_eating import *
from feature_metabolism import *
class Creature(object):
    """description of class"""
    def __init__(self, X, Y, world_grid, layer):
        self.hump = 5
        self.x = X
        self.y = Y
        self.dx = X
        self.dy = Y
        self.age = 0
        self.layer = layer
        self.grid = world_grid
        self.grid[X][Y].single_cell = self

        self.point = Image(Point(X,Y),1,1)
        self.point.setPixel(0,0,'black')

        self.features = []
        self.features.append(feature_brain(self))
        self.features[0].execute = self.features[0].random_move_1p_inwater

        self.features.append(feature_eating(self))
        self.features[1].execute = self.features[1].base_single_cell_plant_eating

        self.features.append(feature_metabolism(self))
        self.features[2].determine_energy_consumption = self.features[2].base_single_cell_metabolism

        self.features.append(feature_moving(self))
    def live(self):
        for feature in self.features:
            feature.execute()



