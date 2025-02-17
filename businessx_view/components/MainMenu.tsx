import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuIndicator,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
  navigationMenuTriggerStyle,
  NavigationMenuViewport,
} from "@/components/ui/navigation-menu";
import { FolderKanban, HandHelping } from "lucide-react";
import Link from "next/link";

function MainMenu() {
  return (
    <NavigationMenu>
      <NavigationMenuList>
        <NavigationMenuItem>
          <Link href="/" legacyBehavior passHref>
            <NavigationMenuLink className={navigationMenuTriggerStyle()}>
              Dashboard
            </NavigationMenuLink>
          </Link>
        </NavigationMenuItem>
        <NavigationMenuItem>
          <NavigationMenuTrigger>Categories</NavigationMenuTrigger>
          <NavigationMenuContent>
            <ul className="grid gap-2 p-2 md:grid-cols-2 md:w-[400px] lg:w-[500px]">
              <li>
                <Link href="/projects" legacyBehavior passHref>
                  <NavigationMenuLink
                    asChild
                    className={navigationMenuTriggerStyle()}
                  >
                    <div className="flex flex-col h-full w-full gap-2 p-2">
                      <div className="flex flex-row gap-2 items-center p-1 w-full">
                        <FolderKanban size={28} />
                        <div className="text-lg font-medium">Projects</div>
                      </div>
                      <p className="text-sm leading-tight text-muted-foreground">
                        Here you can add a new project
                      </p>
                    </div>
                  </NavigationMenuLink>
                </Link>
              </li>
              <li>
                <Link href="/service/add" legacyBehavior passHref>
                  <NavigationMenuLink
                    asChild
                    className={navigationMenuTriggerStyle()}
                  >
                    <div className="flex flex-col h-full w-full gap-2 p-2">
                      <div className="flex flex-row gap-2 items-center p-1 w-full">
                        <HandHelping size={28} />
                        <div className="text-lg font-medium">Services</div>
                      </div>
                      <p className="text-sm leading-tight text-muted-foreground">
                        Here you can add a new services
                      </p>
                    </div>
                  </NavigationMenuLink>
                </Link>
              </li>
              <li>
                <Link href="/customer/add" legacyBehavior passHref>
                  <NavigationMenuLink className={navigationMenuTriggerStyle()}>
                    Customer
                  </NavigationMenuLink>
                </Link>
              </li>
              <li>
                <Link href="/employee/add" legacyBehavior passHref>
                  <NavigationMenuLink className={navigationMenuTriggerStyle()}>
                    Employee
                  </NavigationMenuLink>
                </Link>
              </li>
            </ul>
          </NavigationMenuContent>
        </NavigationMenuItem>
        <NavigationMenuItem>
          <NavigationMenuTrigger>Add New</NavigationMenuTrigger>
          <NavigationMenuContent>
            <ul className="grid gap-2 p-2 md:grid-cols-2 md:w-[400px] lg:w-[500px]">
              <li>
                <Link href="/projects/add" legacyBehavior passHref>
                  <NavigationMenuLink
                    asChild
                    className={navigationMenuTriggerStyle()}
                  >
                    <div className="flex flex-col h-full w-full gap-2 p-2">
                      <div className="flex flex-row gap-2 items-center p-1 w-full">
                        <FolderKanban size={28} />
                        <div className="text-lg font-medium">Projects</div>
                      </div>
                      <p className="text-sm leading-tight text-muted-foreground">
                        Here you can add a new project
                      </p>
                    </div>
                  </NavigationMenuLink>
                </Link>
              </li>
              <li>
                <Link href="/service/add" legacyBehavior passHref>
                  <NavigationMenuLink
                    asChild
                    className={navigationMenuTriggerStyle()}
                  >
                    <div className="flex flex-col h-full w-full gap-2 p-2">
                      <div className="flex flex-row gap-2 items-center p-1 w-full">
                        <HandHelping size={28} />
                        <div className="text-lg font-medium">Services</div>
                      </div>
                      <p className="text-sm leading-tight text-muted-foreground">
                        Here you can add a new services
                      </p>
                    </div>
                  </NavigationMenuLink>
                </Link>
              </li>
              <li>
                <Link href="/customer/add" legacyBehavior passHref>
                  <NavigationMenuLink className={navigationMenuTriggerStyle()}>
                    Customer
                  </NavigationMenuLink>
                </Link>
              </li>
              <li>
                <Link href="/employee/add" legacyBehavior passHref>
                  <NavigationMenuLink className={navigationMenuTriggerStyle()}>
                    Employee
                  </NavigationMenuLink>
                </Link>
              </li>
            </ul>
          </NavigationMenuContent>
        </NavigationMenuItem>
      </NavigationMenuList>
      <NavigationMenuIndicator className="indicator-class" />
      <NavigationMenuViewport />
    </NavigationMenu>
  );
}
export default MainMenu;
