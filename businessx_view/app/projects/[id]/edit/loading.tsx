import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Skeleton } from "@radix-ui/themes";

function Loading() {
  return (
    <Table>
      <TableCaption>A list of your recent projects.</TableCaption>
      <TableHeader>
        <TableRow>
          <TableHead className="font-bold text-amber-200">P-Number</TableHead>
          <TableHead>Project Name</TableHead>
          <TableHead>Start Date</TableHead>
          <TableHead>End Date</TableHead>
          <TableHead>Status</TableHead>
          <TableHead>Actions</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        <TableRow>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
          <TableCell>
            <Skeleton className="h-6 w-full rounded-lg" />
          </TableCell>
        </TableRow>
      </TableBody>
    </Table>
  );
}
export default Loading;
