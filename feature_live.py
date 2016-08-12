class feature_live(object):
    """description of class"""
    def __init__(self, creature):
        self.owner = creature
    def execute(self):
        self.owner.x = 22
    def live_execute_base(self):
        self.owner.x = 22

