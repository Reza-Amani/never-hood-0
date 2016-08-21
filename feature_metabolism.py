from globals import *
from F0_feature import *
class feature_metabolism(feature):
    """description of class"""
    def __init__(self, creature):
        feature.__init__(self, creature)
        self.energy_consumption = 0
        self.max_age = 4000
    def execute(self):
        self.determine_energy_consumption()
        self.owner.hump -= self.energy_consumption
        self.owner.grid[self.owner.x][self.owner.y].organic += self.energy_consumption
        self.owner.age += 1
        if self.owner.age > self.max_age:
            self.kill_owner()
        elif self.owner.hump < 0:
            self.kill_owner()
    def kill_owner(self):
        self.owner.time_to_die = True

    def determine_energy_consumption(self):
        pass
    def base_single_cell_metabolism(self):
        self.energy_consumption = 2
