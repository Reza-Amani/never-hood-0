from globals import *


class WorldPoint(object):
    """description of class"""
    def __init__(self, x, y, organic, single_cell, multi_cell, plant):
        self.x_ = x
        self.y_ = y
        self.organic_ = organic
        self.single_cell__ = single_cell
        self.multi_cell__ = multi_cell
        self.plant__ = plant
        if x >= shallow_water_x:
            self.water = Ewater.dry_land
            self.sunshine = 8
        elif x >= deep_water_x:
            self.water = Ewater.shallow
            self.sunshine = 3
        elif x >= ocean_water_x:
            self.water = Ewater.deep
            self.sunshine = 1
        else:
            self.water = Ewater.ocean
            self.sunshine = 0




