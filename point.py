from globals import *


class WorldPoint(object):
    """description of class"""
    def __init__(self, x=0, y=0, organic=0, single_cell=None, multi_cell=None, plant=None):
        self.x_ = x
        self.y_ = y
        self.organic_ = organic
        self.single_cell__ = single_cell
        self.multi_cell__ = multi_cell
        self.plant__ = plant

    def setup_point(self):
        if self.x_ >= shallow_water_x:
            self.water = Ewater.dry_land
            self.sunshine = 8
        elif self.x_ >= deep_water_x:
            self.water = Ewater.shallow
            self.sunshine = 3
        elif self.x_ >= ocean_water_x:
            self.water = Ewater.deep
            self.sunshine = 1
        else:
            self.water = Ewater.ocean
            self.sunshine = 0




