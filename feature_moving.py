from random import *
from feature import *
class feature_moving(feature):
    def __init__(self, creature):
        feature.__init__(self, creature)
    def execute(self):
        pass
    def random_move_1p(self):
        if self.owner.grid[self.owner.x][self.owner.y].water > 1 : 
            (dx, dy) = choice([(0,0), (0,0), (0,0), (0,0), (0,1), (0,-1), (1,0), (-1,0)])  
            self.owner.x = self.owner.x+dx
            self.owner.y = self.owner.y+dy
            self.owner.p.move(dx,dy)
        
    
