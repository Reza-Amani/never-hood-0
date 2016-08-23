from gc import *
from globals import *
from graphics import *
from random import *
from feature_moving import *
from feature_brain import *
from feature_eating import *
from feature_metabolism import *
from feature_breeding import feature_breeding


class Creature(object):
    """description of class"""
    def __init__(self, X, Y, world_grid, world_creatures, world_field, layer):
        self.hump = 5
        self.time_to_die = False
        self.x = X
        self.y = Y
        self.dx = X
        self.dy = Y
        self.age = 0
        self.layer = layer
        self.grid = world_grid
        self.world_creatures = world_creatures  #it is passed only for accessing by this cr to remove itself when die
                                                #don't use it elsewhere, it is a cheat!
        self.world_field = world_field
        self.grid[X][Y].single_cell = self

        self.point = Image(Point(X,Y),1,1)
        self.point.setPixel(0,0,'DarkGreen')
        self.point.draw(self.world_field)

        self.features = []
        self.features.append(feature_brain(self))
        self.features[0].movement_decision = self.features[0].random_move_1p_inwater

        self.features.append(feature_eating(self))
        self.features[1].execute = self.features[1].base_single_cell_plant_eating

        self.features.append(feature_metabolism(self))
        self.features[2].determine_energy_consumption = self.features[2].base_single_cell_metabolism

        self.features.append(feature_moving(self))

        self.features.append(feature_breeding(self))
        self.features[4].execute = self.features[4].breeding_cell_division

    def die(self):
        self.grid[self.x][self.y].organic += self.hump
#//        self.point.undraw()
        self.grid[self.x][self.y].single_cell = None
        self.world_creatures.remove(self)
        for feature in self.features:
            del feature
        del self.features

    def __del__(self):
        self.point.undraw()
        pass

    def live(self):
        for feature in self.features:
            feature.execute()
        if self.time_to_die:
            self.die()



