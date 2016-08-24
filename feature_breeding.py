﻿from globals import *
from F0_feature import *

class feature_breeding(feature):
    """description of class"""
    def __init__(self, creature):
        feature.__init__(self, creature)
        self.cell_devision_hump_threshold = 1000

    def breeding_cell_division(self):
        if self.owner.hump > self.cell_devision_hump_threshold:
            (dx, dy) = choice([(0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,1), (0,-1), (1,0), (-1,0)])  
            if not self.check_boundaries(self.owner.x+dx, self.owner.y+dy) :
                (dx, dy) = (0, 0)
            if not self.check_vacancy(self.owner.x+dx, self.owner.y+dy) :
                (dx, dy) = (0, 0)
            if dx!=0 or dy!=0:
                child = Creature(self.owner.x+dx,self.owner.y+dy, self.owner.grid, self.owner.world_creatures, self.owner.world_field, "single_cell")
                child.hump = self.owner.hump / 3
                self.owner.hump = self.owner.hump *2/3
                self.owner.world_creatures.append(child)




from creature import *