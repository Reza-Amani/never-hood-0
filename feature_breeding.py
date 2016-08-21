from globals import *
from creature import *
from F0_feature import *
class feature_breeding(feature):
    """description of class"""
    def __init__(self, creature):
        feature.__init__(self, creature)
        self.cell_devision_hump_threshold = 4000

    def execute(self):
        pass

    def breeding_cell_devision(self):
        if self.owner.hump > self.cell_devision_hump_threshold:
            (dx, dy) = choice([(0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,0), (0,1), (0,-1), (1,0), (-1,0)])  
            if not self.check_boundaries(self.owner.x+dx, self.owner.y+dy) :
                (dx, dy) = (0, 0)
            if not self.check_vacancy(self.owner.x+dx, self.owner.y+dy) :
                (dx, dy) = (0, 0)
            if dx!=0 or dy!=0:
                ncr = Creature(self.owner.x+dx,self.owner.y+dy, self.owner.grid, self.owner.world_creatures, "single_cell")
                ncr.point.draw(self.gui.field)
                self.owner.world_creatures.append(cr)




