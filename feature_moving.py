from random import *
from F0_feature import *


class feature_moving(feature):

    def __init__(self, creature):
        feature.__init__(self, creature)

    def execute(self):
        self.owner.point.move(self.owner.dx,self.owner.dy)
        if self.owner.layer == 'single_cell':
            self.owner.grid[self.owner.x][self.owner.y].single_cell = None
            self.owner.x = self.owner.x + self.owner.dx
            self.owner.y = self.owner.y + self.owner.dy
            self.owner.grid[self.owner.x][self.owner.y].single_cell = self.owner      
    
