from globals import *


def check_boundaries(x, y):
    if 0<x<world_size_x and 0<y<world_size_y:
        return True
    else:
        return False

def check_vacancy_single_cell(x, y):
    if 0<x<world_size_x and 0<y<world_size_y:
        return True
    else:
        return False

def Pass():
    pass