CREATE TABLE books (
  id uuid DEFAULT gen_random_uuid (),
  author VARCHAR(256),
  title VARCHAR(256),
  PRIMARY KEY (id)
);
