from globals import *
from F0_feature import *
class feature_eating(feature):
    """description of class"""
    def __init__(self, creature):
        feature.__init__(self, creature)
    def base_single_cell_plant_eating(self):
        self.owner.hump += 4 - self.owner.grid[self.owner.x][self.owner.y].water

