from world import *
from graphics import *
from GUI import *
from globals import *

#from creature import *
#from F0_feature import *


def main():
    print("starting")
    gui = GUI()
    gui.terrain_display()
    world = World(gui)

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
                break;
            elif command == 'clock':
                pace = Epace.single
            elif command == 'pause':
                pace = Epace.stop
            elif command == 'go':
                pace = Epace.go
            elif command == 'restart':
                world.start()
            elif command[0] == 'field':    #a click in field detected
                if world.grid[command[1]][command[2]].single_cell != None:
                    gui.show_point_info("cell info:\nx:%d\ny:%d\nhump:%d\nage:%d\n" \
                    % (world.grid[command[1]][command[2]].x \
                    ,world.grid[command[1]][command[2]].y  \
                    ,world.grid[command[1]][command[2]].single_cell.hump \
                    ,world.grid[command[1]][command[2]].single_cell.age ) )
                else:
                    gui.show_point_info("point info:\nx:%d\ny:%d\norganics:%d\n" \
                    % (world.grid[command[1]][command[2]].x \
                    ,world.grid[command[1]][command[2]].y \
                    ,world.grid[command[1]][command[2]].organic)  )

        if pace in [Epace.single, Epace.go]:
            world.tick()
        if pace == Epace.single:
            pace = Epace.stop
main()
