from globals import *
class point(object):
    """description of class"""
    def __init__(self, X, Y):
        self.x = X 
        self.y = Y
        self.organic = 0
        self.sigle_cell = None
        self.multi_cell = None
        self.plant = None
        if X >= deep_water_x:
            self.water = 4
        elif X >= shallow_water_x:
            self.water = 3
        elif X >= coastal_water_x:
            self.water = 2
        else :
            self.water = 1



