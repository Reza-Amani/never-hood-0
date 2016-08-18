from random import *
from F0_feature import *
class feature_moving(feature):
    def __init__(self, creature):
        feature.__init__(self, creature)
    def execute(self):
        self.owner.point.move(self.owner.dx,self.owner.dy)
        layer = self.owner.layer
        self.owner.grid[self.owner.x][self.owner.y].layer = None
        self.owner.x = self.owner.x + self.owner.dx
        self.owner.y = self.owner.y + self.owner.dy
        self.owner.grid[self.owner.x][self.owner.y].layer = self.owner      
    
