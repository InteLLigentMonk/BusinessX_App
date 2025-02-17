"use client";
import { useParams } from "next/navigation";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { useEffect, useState } from "react";
import { Button } from "@/components/ui/button";
import Link from "next/link";
import { useToast } from "@/hooks/use-toast";
import StatusBadge from "../../../components/StatusBadge";
import { AtSign, CircleUserRound, Headset } from "lucide-react";
import { Project } from "@/app/types/Project";

function ProjectDetailsPage() {
  const [project, setProject] = useState<Project | null>(null);
  const { id } = useParams();

  const { toast } = useToast();

  useEffect(() => {
    fetch(`https://localhost:7036/api/projects/${id}`)
      .then((response) => {
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        return response.json();
      })
      .then((data) => {
        console.log(data);
        setProject(data);
      })
      .catch((error) => {
        toast({
          title: "Error fetching projects",
          description: error.message || "An error occurred",
          variant: "destructive",
        });
      });
  }, [id]);

  return (
    <div className="flex flex-col gap-4 w-full max-w-[800px]">
      <div className="flex items-center justify-between gap-2">
        <p>Project Details</p>
        <Button asChild variant="outline" size="sm" className="border-primary">
          <Link href="/projects">Back</Link>
        </Button>
      </div>
      <Card className=" overflow-hidden">
        <CardHeader className="flex flex-row justify-between items-center bg-secondary w-full p-3">
          <p>P-{id}</p>
          <Button size="sm" className="flex border-primary w-fit">
            <Link href={`/projects/${id}/edit`}>Edit Project</Link>
          </Button>
        </CardHeader>
        <CardContent className="pt-4 flex flex-col gap-2">
          {project ? (
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
              <CardTitle className="md:col-span-2 md:row-start-1 md:col-start-1 flex gap-4 items-center">
                {project.name}
                {StatusBadge(project.statusName)}
              </CardTitle>
              <CardDescription>
                <div>
                  <span className="font-bold">Customer: </span>
                  {project.customerName}
                </div>
              </CardDescription>
              <CardDescription>
                <div>
                  <span className="font-bold">Start Date: </span>
                  {new Date(project.startDate).toLocaleDateString()}
                </div>
              </CardDescription>
              <CardDescription>
                <div>
                  <span className="font-bold">End Date: </span>
                  {new Date(project.endDate).toLocaleDateString()}
                </div>
              </CardDescription>
              <Card className="md:col-start-2 md:row-start-2 md:row-span-4">
                <CardDescription>
                  <div>
                    <CardHeader className="bg-secondary p-2">
                      <span className="font-bold">Customer contact: </span>
                    </CardHeader>
                    <CardContent className="flex flex-col gap-2 p-2">
                      <CardDescription className="flex items-center gap-2">
                        <CircleUserRound size={20} className="inline" />
                        {project.customerContact.firstName}{" "}
                        {project.customerContact.lastName}
                      </CardDescription>
                      <CardDescription className="flex items-center gap-2">
                        <Headset size={20} className="inline" />
                        <div>{project.customerContact.phoneNumber}</div>
                      </CardDescription>
                      <CardDescription className="flex items-center gap-2">
                        <AtSign size={20} className="inline" />
                        <div>{project.customerContact.email}</div>
                      </CardDescription>
                    </CardContent>
                  </div>
                </CardDescription>
              </Card>
              <CardDescription className="md:col-start-1">
                <div>
                  <span className="font-bold">Lead on Project: </span>
                  {project.employeeFirstName} {project.employeeLastName}
                </div>
              </CardDescription>
              <CardDescription className="md:col-start-1">
                <div>
                  <span className="font-bold">Service: </span>
                  {project.serviceName}
                </div>
              </CardDescription>
              <CardDescription className="md:col-span-2">
                <div className="flex items-center justify-between">
                  <span className="font-bold">Description: </span>
                  <span className="pr-2">{`${project.description.length}/400`}</span>
                </div>
                <div className="bg-muted border mt-1 rounded-lg dark:bg-background p-2">
                  {project.description}
                </div>
              </CardDescription>
            </div>
          ) : (
            <p>Loading...</p>
          )}
        </CardContent>
      </Card>
    </div>
  );
}
export default ProjectDetailsPage;
