"use client";
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import Link from "next/link";
import { useEffect, useState } from "react";
import { EyeOpenIcon, Pencil2Icon, TrashIcon } from "@radix-ui/react-icons";
import AlertDialogBox from "./AlertDialogBox";
import StatusBadge from "./StatusBadge";

interface RecentProject {
  id: number;
  name: string;
  endDate: Date;
  statusId: number;
  statusName: string;
}

function ProjectsTable() {
  const [projects, setProjects] = useState<RecentProject[]>([]);
  const [projectToDelete, setProjectToDelete] = useState<number | null>(null);

  useEffect(() => {
    fetch("https://localhost:7036/api/projects/recent")
      .then((response) => response.json())
      .then((data) => {
        setProjects(data);
      })
      .catch((error) => console.error("Error fetching projects:", error));
  }, []);

  const deleteProject = (id: number) => {
    fetch(`https://localhost:7036/api/projects/${id}`, {
      method: "DELETE",
    })
      .then((response) => {
        if (response.ok) {
          setProjects((prevProjects) =>
            prevProjects.filter((project) => project.id !== id)
          );
        } else {
          console.error("Failed to delete project");
        }
      })
      .catch((error) => console.error("Error deleting project:", error));
  };

  const handleDeleteClick = (id: number) => {
    setProjectToDelete(id);
  };

  const handleContinueDelete = () => {
    if (projectToDelete !== null) {
      deleteProject(projectToDelete);
      setProjectToDelete(null);
    }
  };

  return (
    <Table>
      <TableCaption>Total number of projects: {projects.length}</TableCaption>
      <TableHeader>
        <TableRow>
          <TableHead className="font-bold dark:text-amber-200 text-amber-800">
            P-Number
          </TableHead>
          <TableHead>Project Name</TableHead>
          <TableHead>End Date</TableHead>
          <TableHead>Status</TableHead>
          <TableHead className="text-center">Actions</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {projects.map((project) => (
          <TableRow key={project.id}>
            <TableCell className="font-medium">P-{project.id}</TableCell>
            <TableCell className="font-medium">{project.name}</TableCell>

            <TableCell>
              {new Date(project.endDate).toLocaleDateString()}
            </TableCell>
            <TableCell>{StatusBadge(project.statusName)}</TableCell>
            <TableCell className="flex justify-center">
              <div className="flex gap-3">
                <Link href={`/projects/${project.id}`}>
                  <div className="p-1  border border-transparent hover:text-sky-500 hover:rounded-md hover:border-sky-500">
                    <EyeOpenIcon />
                  </div>
                </Link>
                <Link href={`/projects/${project.id}/edit`}>
                  <div className="p-1  border border-transparent hover:text-amber-500 hover:rounded-md hover:border-amber-500">
                    <Pencil2Icon />
                  </div>
                </Link>
                <div onClick={() => handleDeleteClick(project.id)}>
                  <AlertDialogBox
                    trigger={
                      <div className="p-1  border border-transparent hover:text-red-400 hover:rounded-md hover:border-red-400">
                        <TrashIcon />
                      </div>
                    }
                    title="Delete Project"
                    description="Are you sure you want to delete this project?"
                    buttonVariant="destructive"
                    onContinue={handleContinueDelete}
                  />
                </div>
              </div>
            </TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
}
export default ProjectsTable;
