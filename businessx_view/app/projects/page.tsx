import ProjectsTable from "@/components/ProjectsTable";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { FilePlusIcon } from "@radix-ui/react-icons";

import Link from "next/link";

function page() {
  return (
    <Card className="w-full  overflow-hidden">
      <CardHeader className="flex md:flex-row justify-between">
        <div className="flex justify-between w-full">
          <div>
            <CardTitle>All Projects</CardTitle>
            <CardDescription>
              List of all current registered projects.
            </CardDescription>
          </div>
          <Button asChild size={"lg"}>
            <Link href="/projects/add">
              <FilePlusIcon />{" "}
              <p className="hidden md:flex ">Add New Project</p>
            </Link>
          </Button>
        </div>
      </CardHeader>
      <CardContent>
        <ProjectsTable />
      </CardContent>
      <CardFooter></CardFooter>
    </Card>
  );
}
export default page;
