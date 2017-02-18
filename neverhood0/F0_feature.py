from globals import *
class feature(object):
    """description of class"""
    def __init__(self, creature):
        self.owner = creature
    def execute(self):
        pass
 
    def check_boundaries(self, nx, ny):
        if nx > world_size_x or nx < 0 or ny > world_size_y or ny < 0 :
            return False
        else :
            return True

    def check_vacancy(self, nx, ny):
        if self.owner.grid[nx][ny].single_cell == None :
            return True
        else :
            return False


