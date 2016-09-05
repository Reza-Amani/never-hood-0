from world import *
from graphics import *
from GUI import *
from globals import *


def main():
    print("starting")
    gui = GUI()
    gui.terrain_display()
    world = World(gui)
    obj_under_monitor = None
    pace = Epace.stop
    while True:
        command = gui.get_command()
        if command not in ['None','Null']:
            gui.show_message(command[0])
            if command == "exit":
                gui.field.close()
                gui.control.close()
                gui.monitor.close()
                del gui
                #del world
                break
            elif command =='save':
                world.save()
            elif command == 'clock':
                pace = Epace.single
            elif command == 'pause':
                pace = Epace.stop
            elif command == 'go':
                pace = Epace.go
            elif command == 'restart':
                world.start()

            if command[0] == 'field':    # click in field detected
                if world.grid_[command[1]][command[2]].single_cell_ is not None:
                    obj_under_monitor = world.grid_[command[1]][command[2]].single_cell_
                else:
                    obj_under_monitor = world.grid_[command[1]][command[2]]

        if obj_under_monitor is not None:
            gui.show_point_info(serialise(obj_under_monitor))

        if pace in [Epace.single, Epace.go]:
            world.tick()
        if pace == Epace.single:
            pace = Epace.stop
main()
